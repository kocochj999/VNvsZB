using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments : MonoBehaviour
{
    public GameObject WeaponObject;

    public GameObject armor;
    public GameObject helmet;
    public Weapons weapon; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponObject.GetComponent<SpriteRenderer>().sprite = weapon.icon;
    }
}
