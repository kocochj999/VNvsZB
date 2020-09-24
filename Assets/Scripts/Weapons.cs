using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapons : ScriptableObject
{
    public int type;
    public string itemName;
    public Sprite icon;

    public float damage;
    public float attackDelay;

    public Weapons()
    {
        
    }

    public Weapons(int type, string itemName,Sprite icon,float attackDelay)
    {
        this.type = type;
        this.itemName = itemName;
        this.icon = icon;

        this.attackDelay = attackDelay;
    }
}
