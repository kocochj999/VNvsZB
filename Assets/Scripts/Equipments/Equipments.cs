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
        if(WeaponController.instance.weapon != null)
        {
            weapon.GetComponent<SpriteRenderer>().sprite = WeaponController.instance.weapon.icon;
        }
        if(HatController.instance.hat != null)
        {
            hat.GetComponent<SpriteRenderer>().sprite = HatController.instance.hat.icon;
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
