using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments : MonoBehaviour
{
    public static Equipments instance;
    public GameObject weapon;
    public GameObject hat;
    public GameObject armor;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon == null)
        {
            WeaponController.instance.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            WeaponController.instance.GetComponent<SpriteRenderer>().sprite = WeaponController.instance.weapon.icon;
        }
        if(hat == null)
        {
            //HatController.instance.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
           // HatController.instance.GetComponent<SpriteRenderer>().sprite = HatController.instance.hat.icon;
            
        }
        if(armor == null)
        {
            //ArmorController.instance.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            //ArmorController.instance.GetComponent<SpriteRenderer>().sprite = ArmorController.instance.armor.icon;
        }
    }
}
