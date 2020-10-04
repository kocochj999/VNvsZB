using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEditorInternal;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody2D rb;
    private Animator anim;
    
    private enum State { normal, hurt, dead}
    private State state = State.normal;

    public float health;
    private float moveForce = 3.5f;
    private float vulnerableTimer;
    private float vulnerableResetTime;
    public bool vulnerable = true;
    public bool isDead = false;

    







    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        health = 100;
        vulnerableTimer = 0f;
        vulnerableResetTime = 3f;

        
    }
    void Update()
    {
        if(!isDead)
        {
            Movement();
            if (!vulnerable)
            {
                vulnerableTimer += Time.deltaTime;

            }
            
            if (vulnerableTimer >= vulnerableResetTime)
            {
                vulnerableTimer = 0;
                vulnerable = true;
            }
        }
        if (health <= 0)
        {
            isDead = true;
            GameController.instance.GameOver();
        }
        StateSwitch();
        anim.SetInteger("state", (int)state);

        
}
private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vDirection = Input.GetAxis("Vertical") * Time.deltaTime ;
        if(hDirection >0)
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
        }
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-moveForce, rb.velocity.y);
        }
        if (vDirection > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveForce);
        }
        if (vDirection < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveForce);
        }
    }
    private void StateHandler()
    {

    }
    
    public void getBitten(GameObject zombieObject)
    {
        if(ArmorController.instance.isCharged)
        {
            health -= (zombieObject.GetComponent<Zombie>().biteDamage - ArmorController.instance.armorValue - ArmorController.instance.addedValue);
            ArmorController.instance.isCharged = false;
            ArmorController.instance.shieldTimer = 0;
        }
        else
        {
            health -= (zombieObject.GetComponent<Zombie>().biteDamage - ArmorController.instance.armorValue);
        }
        
        zombieObject.GetComponent<Zombie>().health -= ArmorController.instance.armorDamage;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    
        if(collision.transform.tag == "ZB" && vulnerable)
        {
            ArmorController.instance.isCharged = false;
            vulnerable = false;
            getBitten(collision.gameObject);
        }
    }
  
        
    private void StateSwitch()
    {
        if(!vulnerable)
        {
            state = State.hurt;

            if(isDead)
            {
                state = State.dead;
            }
        }
        
        else
        {
            state = State.normal;
        }
    }
    public void PullTrigger(Vector3 target, Vector3 difference, float rotationZ)
    {
        WeaponController.instance.Shoot(target, difference, rotationZ);
    }
    



}
