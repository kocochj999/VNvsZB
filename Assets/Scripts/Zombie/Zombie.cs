using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Zombie : MonoBehaviour
{
    
    
    
    public Rigidbody2D rb;

    public Transform player;
    public Transform center;
    public Transform shooter;
    public bool canChase = false;
    public bool isHurt = false;
    
    private float maxDistance = 12f;

    //private bool canBite = true;

    public float health;
    public float biteDamage;
    public float hurtTimer;
    public float hurtResetTime;
    public float moveSpeed;

    //HealthBar
    public HealthBar healthBar;

    
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();

        healthBar.setMaxHealth(health);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        healthBar.setHealthBar(health);
        if (Vector2.Distance(transform.position, player.position) < 45f)
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
            rb.velocity = Vector2.zero;
        }

        if (canChase && !PlayerController.instance.isDead)
        {
            ChaseFilter();
        }

        if (health <= 0)
        {
            Dead(shooter);
        }
        if(PlayerController.instance.isDead)
        {
            rb.velocity = Vector2.zero;
        }

    }

    public virtual void Dead(Transform shooter)
    {
        Destroy(this.transform.parent.gameObject);
        //player who fire the bullet. Bullet get do-er (in case of multiplayer)
        shooter.GetComponent<PlayerController>().GetPoint(1);
    }

    public void GettingShot(GameObject gO)
    {
        shooter = gO.GetComponent<Bullet>().shooter;
        health-= gO.GetComponent<Bullet>().damage;
        isHurt = true;
        rb.velocity = Vector2.zero;
    }

    public void GetExploded(GameObject gO)
    {
        shooter = gO.GetComponent<Mine>().planter;
        health -= gO.GetComponent<Mine>().mineDamage;
        isHurt = true;
        rb.velocity = Vector2.zero;
    }

    public void Chase(Transform target, float moveSpeed)
    {
        Vector3 difference = target.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        

    }

    public void ChaseFilter()
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

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && PlayerController.instance.vulnerable)
        {
            isHurt = true;
            rb.velocity = Vector2.zero;
            PlayerController.instance.getBitten(gameObject);
            PlayerController.instance.vulnerable = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && PlayerController.instance.vulnerable)
        {
            isHurt = true;
            rb.velocity = Vector2.zero;
            
        }
    }
    
}
