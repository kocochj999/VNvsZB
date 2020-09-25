using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments : MonoBehaviour
{
    static public Equipments instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject armor;
    public GameObject helmet;
    public GameObject weapon; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon == null)
        {
            WeaponController.instance.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            WeaponController.instance.GetComponent<SpriteRenderer>().sprite = WeaponController.instance.weapon.icon;
        }
        
    }
}
