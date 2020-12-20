using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static WeaponController instance;
    public Weapons weapon;
    public GameObject shooter;
    public GameObject[] weaponHolder;

    public float damage;
    public float fireRate;
    public float fireRange;
    public float bulletSpeed;

    public GameObject fireRangeObj;
    public GameObject bulletPrefab;
    public GameObject[] bulletStart;
    public AudioClip fireSound;

    private AudioSource audioSource;

    public float timeCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (weapon !=null)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = weapon.icon;
            this.damage = weapon.damage + PlayerController.instance.baseDamage;
            this.fireRate = weapon.fireRate;
            this.fireRange = weapon.fireRange;
            this.bulletSpeed = weapon.bulletSpeed;

            if (weapon.type == 1) //neu weapon la Gun
            {
                Gun gun = (Gun) weapon;
                this.bulletPrefab = gun.bulletPrefab;
                this.bulletPrefab.GetComponent<Bullet>().damage = this.damage;
                this.bulletPrefab.GetComponent<Bullet>().culpritWeapon = this;
                this.bulletPrefab.GetComponent<Bullet>().shooter = this.shooter.transform;
                this.bulletStart = new GameObject[gun.holderCapacity];
                GameObject.FindGameObjectWithTag("SelfDestroyLine").GetComponent<CircleCollider2D>().radius = fireRange;
                try
                {
                    this.bulletStart[0] = GameObject.FindGameObjectWithTag("BulletStart1");
                    this.bulletStart[1] = GameObject.FindGameObjectWithTag("BulletStart2");
                    
                }
                catch
                {
                    
                }
            }
            timeCount -= Time.deltaTime;
        }
    }
    public void Shoot(Vector3 target, Vector3 difference, float rotationZ)
    {
        if(timeCount <= 0)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
            timeCount = fireRate;
        }
        
    }
    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart[0].transform.position;
        b.transform.rotation = UnityEngine.Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        
        audioSource.PlayOneShot(weapon.fireSound);
    }
    
}
