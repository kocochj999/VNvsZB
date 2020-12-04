﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField]
    private ScriptableObject[] SOList;
    [SerializeField]
    private ScriptableObject theChosenOne;

    void Start ()
    {
        Random rd = new Random();
        int num = Random.Range(0,SOList.Length);
        theChosenOne = SOList[num];
    }

    void Update()
    {
        if (theChosenOne!=null)
        {
            ItemScriptable ISItem = (ItemScriptable) theChosenOne;
            this.gameObject.GetComponent<SpriteRenderer>().sprite =  ISItem.icon;
        }
    }

}
