using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mine : MonoBehaviour
{

    public float mineDamage;
    public float explodeRadius;
    public GameObject floatingDmg;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        mineDamage = 50f;
        explodeRadius = 1.5f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AfterExplosion()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ZB")
        {
            anim.SetTrigger("explode");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRadius);
            foreach(Collider2D hit in colliders)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if(rb != null && rb.tag == "ZB")
                {
                    Zombie zb = hit.GetComponent<Zombie>();
                    GameObject floatingParent = Instantiate(floatingDmg, zb.transform.position, Quaternion.identity) as GameObject;
                    
                    floatingParent.transform.GetChild(0).GetComponent<TextMeshPro>().text = mineDamage.ToString();
                    zb.GetExploded(gameObject); 
                }
                
                
            }
            
            
        }
    }
}
