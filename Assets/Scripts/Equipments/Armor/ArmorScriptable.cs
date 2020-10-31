using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScriptable : ScriptableObject
{
    public Sprite icon;
    public int armorType;
    public string armorName;
    public int armorLevel;
    public float armorValue;
   
    

    public ArmorScriptable()
    {

    }
    public ArmorScriptable(Sprite icon, int type, string name, int lvl, float value)
    {
        this.icon = icon;
        this.armorType = type;
        this.armorName = name;
        this.armorLevel = lvl;
        this.armorValue = value;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
