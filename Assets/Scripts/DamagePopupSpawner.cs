using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DamagePopupSpawner : MonoBehaviour
{
    public static DamagePopupSpawner instance;
    [SerializeField]
    private GameObject damagePrefab;


    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }

    public void Create(float dmg,Vector3 tf){
        GameObject go = Instantiate(damagePrefab,tf,Quaternion.identity);
        go.GetComponent<TextMeshPro>().text = dmg.ToString();
    }
}
