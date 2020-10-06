using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField]
    private float timeExist = 2;
    private TextMeshPro tmp;

    void Start(){
        tmp = this.gameObject.GetComponent<TextMeshPro>();
    }
    
    void FixedUpdate(){
        this.gameObject.transform.position += UnityEngine.Vector3.up * Time.deltaTime;
        if (timeExist>0){
            timeExist-= Time.deltaTime;
            if (timeExist>1f){
                tmp.fontSize += Time.deltaTime;
            }
            else{
                tmp.fontSize -= Time.deltaTime;
            }

        }
        else{
            Destroy(gameObject);
        }
    }
}
