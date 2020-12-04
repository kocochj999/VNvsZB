using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : ItemScriptable
{
    public int type;

    public float damage;
    public float fireRate;
    public float fireRange;
    public int bulletPerShot;

    public AudioClip fireSound;

    public float bulletSpeed;

    public Weapons()
    {

    }

    public Weapons(Sprite icon, int type, string name, float damge, float fireRate, float range, int bulletPerShot, float speed, AudioClip fireSound) : base(icon,name)
    {
        this.type = type;
        this.damage = damge;
        this.fireRate = fireRate;
        this.fireRange = range;
        this.bulletPerShot = bulletPerShot;
        this.bulletSpeed = speed;
        this.fireSound = fireSound;
    }    
}
