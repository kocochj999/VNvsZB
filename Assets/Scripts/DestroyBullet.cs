﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ZB")
        {
            Destroy(gameObject);
            Zombie zb = collision.gameObject.GetComponent<Zombie>();
            zb.GettingShot(gameObject);
        }
    }

}
