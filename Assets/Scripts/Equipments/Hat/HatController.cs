﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public static HatController instance;
    public Hat hat;

    
    public float addedHealth;
    public int hpPerSec;


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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hat!=null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hat.icon;
        
            if(hat.type == 1)
            {
                MuCoi muCoi = (MuCoi)hat;

                this.addedHealth = muCoi.addedHealth;
            }
            if(hat.type == 2)
            {
                NonLa nonLa = (NonLa)hat;
                this.hpPerSec = nonLa.hpPerSec;
            }
            if (hat.type == 3)
            {
                MuCoiLa muCoiLa = (MuCoiLa)hat;
                this.hpPerSec = muCoiLa.hpPerSec;
                this.addedHealth = muCoiLa.addHealth;
            }
        }
        
    }
}
