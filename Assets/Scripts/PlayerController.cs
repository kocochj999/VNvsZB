using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditorInternal;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private float moveForce = 3.5f;
    private int healthPoint;
    private float speed;
    private float hitDamge;
    private float fireRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        
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
    /* private void Shoot()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 100f)) // if gì đây a -> if có raycast :)) nhặt trên mạng em ui
            // Kiểu bắn trong game này ko nên dùng raycast, để e cho a xem cái video này rồi làm giống nó
            // raycast dùng trong mấy cái bắn nó loằng ngoằng hơn thôi.
        {
            Debug.DrawLine(ray.origin, hit.point, Color.black);
            Debug.Log("Shot fired.");
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * 10f, Color.black);
            Debug.Log("Shot fired but didnt hit anyone");
        }

    }*/

}
