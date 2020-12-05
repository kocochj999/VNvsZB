using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : Zombie
{
    public float skillCoolDown = 10f;
    public bool canCastSkill = true;
    public float skillTimer = 0f;
    public bool castingSkill = false;
    public float castingSkillTime = 2f;
    public float castingTimer = 0f;


    public GameObject ItemDroppingPrefab;

    public override void Update()
    {
        base.Update();
        if (Vector2.Distance(transform.position, player.position) < 10f && canCastSkill)
        {
            CastSkill();
        }
        if (!canCastSkill)
        {
            skillTimer += Time.deltaTime;
            if(skillTimer >= skillCoolDown)
            {
                canCastSkill = true;
                skillTimer = 0f;
            }
        }
        if (castingSkill)
        {
            base.isHurt = true;
            castingTimer += Time.deltaTime;
            if(castingTimer >= castingSkillTime)
            {
                castingSkill = false;
                castingTimer = 0f;
                base.isHurt = false;
            }
        }
    }
    public void CastSkill()
    {
        castingSkill = true;
        //cast skill with target is player
        canCastSkill = false;
    }

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
