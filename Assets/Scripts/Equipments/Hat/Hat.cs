using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hat : ScriptableObject
{
    public Sprite icon;
    public string hatName;
    public int hatType;
    
    

    public Hat()
    {

    }
    public Hat(Sprite icon, string name, int type)
    {
        this.icon = icon;
        this.hatName = name;
        this.hatType = type;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
