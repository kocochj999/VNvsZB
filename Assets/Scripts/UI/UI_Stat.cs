    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stat : MonoBehaviour
{
    public TextMeshProUGUI hp;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI power;

    [SerializeField] private int pointCost;
    private void Update()
    {
        hp.text = PlayerController.instance.baseHP.ToString();
        armor.text = PlayerController.instance.baseArmor.ToString();
        power.text = PlayerController.instance.baseDamage.ToString();
    }
    public bool canUpgrade()
    {
        if(PlayerController.instance.point >= pointCost)
        {
            return true;
        }
        return false;
    }
    public void upgradeHealth(int hp)
    {
        if (canUpgrade())
        {
            Debug.Log("hp up-ed by:" + hp);
            PlayerController.instance.baseHP += hp;
            PlayerController.instance.point -= pointCost;
        }
        
    }   
    public void upgradeArmor(int armor)
    {
        if (canUpgrade())
        {
            PlayerController.instance.baseArmor += armor;
            Debug.Log("Armor up-ed by:" + armor);
            PlayerController.instance.point -= pointCost;
        }
    }
    public void upgradePower(int power)
    {
        if (canUpgrade())
        {
            PlayerController.instance.baseDamage += power;
            Debug.Log("Power up-ed by:" + power);
            PlayerController.instance.point -= pointCost;
        }
    }
}
