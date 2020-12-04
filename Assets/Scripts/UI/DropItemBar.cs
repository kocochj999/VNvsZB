using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropItemBar : MonoBehaviour
{
    public GameObject DropItem;
    public GameObject ItemText;

    void Start()
    {
         ItemText.GetComponent<TextMeshPro>().text = DropItem.GetComponent<ItemDropper>().theChosenOne.name;
    }
}
