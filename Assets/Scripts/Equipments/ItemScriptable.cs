using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptable : ScriptableObject
{
    public Sprite icon;
    public string name;

    public ItemScriptable()
    {
    
    }

    public ItemScriptable(Sprite icon, string name)
    {
        this.icon = icon;
        this.name = name;
    }
}
