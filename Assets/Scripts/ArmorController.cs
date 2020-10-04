using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : MonoBehaviour
{
    public static ArmorController instance;
    //Armor
    public ArmorScriptable armor;
    public int armorType;
    public string armorName;
    public int armorLevel;
    public float armorValue;
    public float armorDamage;
    public float addedValue;
    public float chargeTime;
    public bool isCharged;

    public float shieldTimer;

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
        shieldTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.armorType = armor.armorType;
        this.armorName = armor.armorName;
        this.armorLevel = armor.armorLevel;
        this.armorValue = armor.armorValue;

        if (armor.armorType == 1)
        {

        }
        if (armor.armorType == 2)
        {
            Blademail blademail = (Blademail)armor;
            this.armorDamage = blademail.armorDamage;
        }
        if (armor.armorType == 3)
        {
            Shield shield = (Shield)armor;
            this.addedValue = shield.addedValue;
            this.chargeTime = shield.chargeTime;
            //this.isCharged = shield.isCharge;
        }

        shieldTimer += Time.deltaTime;
        if (isCharged == false && shieldTimer >= chargeTime)
        {
            isCharged = true;

        }
    }
}
