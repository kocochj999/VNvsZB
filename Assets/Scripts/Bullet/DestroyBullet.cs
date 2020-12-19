using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    //FloatingDMG
    public GameObject floatingDmg;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SelfDestroyLine")
        {
            Destroy(gameObject);
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "SelfDestroyLine")
        {
            if (collision.gameObject.tag == "Edge")
            {
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "ZB")
            {
                Destroy(gameObject);
                Zombie zb = collision.gameObject.GetComponent<Zombie>();
                GameObject floatingParent = Instantiate(floatingDmg, zb.transform.position, Quaternion.identity) as GameObject;
                floatingParent.transform.GetChild(0).GetComponent<TextMeshPro>().text = WeaponController.instance.damage.ToString();
                zb.GettingShot(gameObject);
            }
            if(collision.gameObject.tag == "Mine")
            {
                Destroy(gameObject);
            }
        }
        
        
    }

}
