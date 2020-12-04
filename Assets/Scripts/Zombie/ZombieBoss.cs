using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : Zombie
{
    public GameObject ItemDroppingPrefab;
    
    
    public override void Dead()
    {
        base.Dead();
        RandomInstantiateDroppingItem();
    }

    private void RandomInstantiateDroppingItem()
    {
        
        int numb = Random.Range(0,100);
        Debug.Log(numb);
        if (numb%3==0)
        {
            Instantiate(ItemDroppingPrefab, this.gameObject.transform.position,Quaternion.identity);
        }
    }
}
