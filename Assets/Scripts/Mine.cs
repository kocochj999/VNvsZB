using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditorInternal;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float range;
    private float delay = 0;

    private enum State {exist,explode}
    private State state;
    private Animator anim;
    private CircleCollider2D collider;

    void Start(){
        anim = this.gameObject.GetComponent<Animator>();
        state = State.exist;
        collider = this.gameObject.GetComponent<CircleCollider2D>();
        collider.radius = range;
    }

    private void Explode()
    {
        state = State.explode;
        anim.SetInteger("isExplode",(int) state);
        UnityEngine.Debug.Log(anim.GetCurrentAnimatorStateInfo(0).length);
        if (state == State.explode)
        {
            
           Destroy(this.gameObject, anim.GetCurrentAnimatorStateInfo(0).length + delay); 
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ZB")){
            UnityEngine.Debug.Log("oke");
            Explode();
        }
    }
}
