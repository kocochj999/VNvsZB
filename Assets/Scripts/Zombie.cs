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


    private int health;
    private float biteDamge;

    // Start is called before the first frame update
    void Start()
    {
        hurtResetTime = 0.2f;
        hurtTimer = 0f;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();
        health = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.y > 14.5f)
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

        if (canChase)
        {
            ChaseFilter();
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("is Hurt:" + isHurt);
        Debug.Log("canChase: " + canChase);

    }
    public void GettingShot()
    {
        health--;
        isHurt = true;
    }
    private void Chase(Transform target, float moveSpeed)
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

    }
    private void ChaseFilter()
    {
        
        if (Vector2.Distance(transform.position, player.position) >= maxDistance)
        {
            Chase(center, 2f);
        }
        else
        {
            Chase(player, 3.5f);

        }
    }
    
}
