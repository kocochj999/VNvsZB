using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : Zombie
{
    public GameObject ItemDroppingPrefab;
    
    
    public override void Dead()
    {
        base.Dead();
        Instantiate(ItemDroppingPrefab, this.gameObject.transform.position,Quaternion.identity);
    }
}
