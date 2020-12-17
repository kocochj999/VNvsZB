using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ZombieBoss : Zombie
{
    public float skillCoolDown = 10f;
    public bool canCastSkill = true;
    public float skillTimer = 0f;
    public bool castingSkill = false;
    public float castingSkillTime = 2f;
    public float castingTimer = 0f;

    //Skill properties
    public GameObject skillStart;
    public GameObject skillPrefab;
    public float skillSpeed = 1.5f;


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
        Vector3 difference = player.position - base.transform.position ;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        GameObject skill = Instantiate(skillPrefab) as GameObject;
        skill.transform.position = skillStart.transform.position;
        skill.GetComponent<Rigidbody2D>().velocity = direction * skillSpeed;

        canCastSkill = false;
    }

    public override void Dead()
    {
        base.Dead();
        player.GetComponent<PlayerController>().GetPoint(2);
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
