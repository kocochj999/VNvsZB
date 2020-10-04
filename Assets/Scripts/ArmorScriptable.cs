using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScriptable : ScriptableObject
{
    public int armorType;
    public string armorName;
    public int armorLevel;
    public float armorValue;
   
    

    public ArmorScriptable()
    {

    }
    public ArmorScriptable(int type, string name, int lvl, float value)
    {
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
