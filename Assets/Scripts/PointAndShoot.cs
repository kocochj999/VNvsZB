﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    
    


    
    private UnityEngine.Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.isDead == false)
        {
            target = GetComponent<Camera>().ScreenToWorldPoint(new UnityEngine.Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crosshairs.transform.position = new UnityEngine.Vector2(target.x, target.y);

            Vector3 difference = target - this.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            if (Input.GetMouseButtonDown(0))
            {
                PlayerController.instance.Shoot(difference,target,rotationZ);
            }
        }
        
        
    }

   
}
