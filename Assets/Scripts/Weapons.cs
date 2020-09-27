using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : ScriptableObject
{
    public Sprite icon;

    public int weaponType;
    public string weaponName;

    public float damge;
    public float fireRate;
    public float fireRange;
    public int bulletPerShot;

    //Bullet
    private float bulletSpeed;

    public Weapons()
    {

    }
    public Weapons(Sprite icon, int type, string name, float damge, float fireRate, float range, int bulletPerShot, float speed)
    {
        this.icon = icon;
        this.weaponType = type;
        this.weaponName = name;
        this.damge = damge;
        this.fireRate = fireRate;
        this.fireRange = range;
        this.bulletPerShot = bulletPerShot;
        this.bulletSpeed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shoot()
    {

    }
    
}
