using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Zombie : MonoBehaviour
{
    
    private Rigidbody2D rb;

    private Transform player;
    private Transform center;
    private bool canChase = false;
    private bool isHurt = false;
    private float hurtTimer;
    private float hurtResetTime;
    private float maxDistance = 10f;

    //private bool canBite = true;

    public float health;
    public float biteDamage;
    public float moveSpeed = 4;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();

        hurtResetTime = 0.2f;
        hurtTimer = 0f;
        health = 200;
        biteDamage = 40f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= 14.5f)
        {
            canChase = true;
        }
        
        if (isHurt == true)
        {
            canChase = false;
            hurtTimer += Time.deltaTime;
        }
        if (hurtTimer >= hurtResetTime)
        {
            hurtTimer = 0;
            isHurt = false;
            canChase = true;
        }

        if (canChase && !PlayerController.instance.isDead)
        {
            ChaseFilter();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if(PlayerController.instance.isDead)
        {
            rb.velocity = Vector2.zero;
        }

    }
    public void GettingShot(GameObject gO)
    {
        health-= gO.GetComponent<Bullet>().damage;
        isHurt = true;
        rb.velocity = Vector2.zero;
    }
    private void Chase(Transform target, float moveSpeed)
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

    }
    private void ChaseFilter()
    {
        
        if (Vector2.Distance(transform.position, player.position) >= maxDistance)
        {
            Chase(center, moveSpeed/2);
        }
        else
        {
            Chase(player, moveSpeed);

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && PlayerController.instance.vulnerable)
        {
            rb.velocity = Vector2.zero;
            PlayerController.instance.getBitten(gameObject);
            PlayerController.instance.vulnerable = false;
        }
    }

}
