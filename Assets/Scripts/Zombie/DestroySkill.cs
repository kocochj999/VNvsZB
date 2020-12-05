using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySkill : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SelfDestroyLine")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);


    }


}
