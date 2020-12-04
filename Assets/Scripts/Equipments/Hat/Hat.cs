using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : ItemScriptable
{
    public int type;

    public Hat()
    {
    
    }

    public Hat(int type, Sprite icon, string name) : base(icon,name)
    {
        this.type = type;
    }
}
