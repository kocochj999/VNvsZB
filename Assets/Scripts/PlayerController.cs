using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEditorInternal;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    
    private enum State { normal, hurt, dead}
    private State state = State.normal;

    public int health;
    private float vulnerableTimer;
    private float vulnerableResetTime;
    public bool vulnerable = true;
    public bool isDead = false;

    private float moveForce = 3.5f;


    public AudioClip fireSound;

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
        audioSource = GetComponent<AudioSource>();

        health = 3;
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
        if (health == 0)
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void getBitten()
    {
        health--;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    
        if(collision.transform.tag == "ZB" && vulnerable)
        {
            vulnerable = false;
            getBitten();
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
    
    public void Shoot(Vector3 difference,Vector3 target,float rotationZ)
    {
        Equipments.instance.weapon.GetComponent<WeaponController>().Shoot(difference,target,rotationZ);
    }

    
}
