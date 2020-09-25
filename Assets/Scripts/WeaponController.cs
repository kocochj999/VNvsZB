using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static WeaponController instance;

    public Weapons weapon;

    public float damage;
    public float delay;

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

    void Update()
    {
        this.damage = weapon.damage;
        this.delay = weapon.attackDelay;
        this.GetComponent<SpriteRenderer>().sprite = weapon.icon;

    }
}
