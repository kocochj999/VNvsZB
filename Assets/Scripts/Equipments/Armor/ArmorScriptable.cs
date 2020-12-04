using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScriptable : ItemScriptable
{
    public int type;
    public int armorLevel;
    public float armorValue;
   
    public ArmorScriptable()
    {

    }

    public ArmorScriptable(Sprite icon, int type, string name, int lvl, float value) : base(icon,name)
    {
        this.type = type;
        this.armorLevel = lvl;
        this.armorValue = value;
        
    }
}
