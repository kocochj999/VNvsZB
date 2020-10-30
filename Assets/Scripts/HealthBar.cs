using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public Transform owner;

    private void Update()
    {
        if(owner == null)
        {
            Destroy(gameObject);
        }
        if (owner!=null)
        {
        transform.position = owner.position + new Vector3(0, 1f) ;
        }
        
    }
    public void setMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }
    public void setHealthBar(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
