using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : ScriptableObject
{
    public Sprite icon;

    public int weaponType;
    public string weaponName;

    public float damage;
    public float fireRate;
    public float fireRange;
    public int bulletPerShot;

    public AudioClip fireSound;

    //Bullet
    public float bulletSpeed;

    public Weapons()
    {

    }
    public Weapons(Sprite icon, int type, string name, float damge, float fireRate, float range, int bulletPerShot, float speed, AudioClip fireSound)
    {
        this.icon = icon;
        this.weaponType = type;
        this.weaponName = name;
        this.damage = damge;
        this.fireRate = fireRate;
        this.fireRange = range;
        this.bulletPerShot = bulletPerShot;
        this.bulletSpeed = speed;
        this.fireSound = fireSound;
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
