using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static WeaponController instance;

    public Weapons weapon;
    public GameObject bullet;
    public GameObject[] BulletStart;
    
    public float timeCount=0;
    public float damage;
    public float delay;
    public float speed;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        this.damage = weapon.damage;
        this.delay = weapon.attackDelay;
        this.speed = weapon.speed;
        
        if (weapon.type == 1) // Sung luc
        {
            Gun gun = (Gun) weapon;
            this.bullet = gun.bullet;
            this.bullet.GetComponent<Bullet>().damage = this.damage;
            this.BulletStart = new GameObject[gun.bulletSize];
            try
            {
                this.BulletStart[0] = GameObject.FindGameObjectWithTag("StartBullet1");
                this.BulletStart[1] = GameObject.FindGameObjectWithTag("StartBullet2");
            }
            catch
            {
            
            }
        }
         timeCount -= Time.deltaTime;
    }

    public void Shoot(Vector3 difference,Vector3 target,float rotationZ)
    {
        if (timeCount<=0)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
            timeCount = delay;
        }
        else
        {
           
        }
        
    }

    private void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = BulletStart[0].transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * speed;
        PlayerController.instance.PlaySound(PlayerController.instance.fireSound );
        GameObject c = Instantiate(bullet) as GameObject;
        c.transform.position = BulletStart[1].transform.position;
        c.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        c.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
    
}
