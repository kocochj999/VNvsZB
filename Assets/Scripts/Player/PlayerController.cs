using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody2D rb;
    private Animator anim;
    
    private enum State { normal, hurt, dead}
    private State state = State.normal;

    //Stat
    public float health;
    public float maxHealth;
    private float moveForce = 3.5f;
    public float baseArmor;
    public float baseDamage;
    public float baseHP;



    private float vulnerableTimer;
    public float vulnerableResetTime;
    public bool vulnerable = true;
    public bool isDead = false;

    

    //Stat UI
    public GameObject statUI;
    //mine
    public GameObject minePrefab;

    //HealthBar
    public HealthBar healthBar;

    //Point
    public int point = 0;
    [SerializeField] private TextMeshProUGUI pointCount;

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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        health = baseHP;
        vulnerableTimer = 0f;
        vulnerableResetTime = 3f;
        
    }
    void Update()
    {
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealthBar(health);
        
        if (!isDead)
        {
            Movement();
            PlantMine();
            ToggleStatUI();
            if (!vulnerable)
            {
                vulnerableTimer += Time.deltaTime;

            }
            
            if (vulnerableTimer >= vulnerableResetTime)
            {
                vulnerableTimer = 0;
                vulnerable = true;
            }
        }
        if (health <= 0)
        {
            isDead = true;
            GameController.instance.GameOver();
        }
        StateSwitch();
        anim.SetInteger("state", (int)state);
        //hat updates
       
        maxHealth = baseHP + Equipments.instance.hat.GetComponent<HatController>().addedHealth;
        
        if(health < maxHealth)
        {
            health += Equipments.instance.hat.GetComponent<HatController>().hpPerSec * Time.deltaTime;
        }
}
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vDirection = Input.GetAxis("Vertical") * Time.deltaTime ;
        if(hDirection >0)
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
        }
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-moveForce, rb.velocity.y);
        }
        if (vDirection > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveForce);
        }
        if (vDirection < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveForce);
        }
    }
    private void StateHandler()
    {

    }
    
    public void getBitten(GameObject zombieObject)
    {
        if(Equipments.instance.armor.GetComponent<ArmorController>().isCharged)
        {
            health -= (zombieObject.GetComponent<Zombie>().biteDamage - (Equipments.instance.armor.GetComponent<ArmorController>().armorValue + this.baseArmor) - ArmorController.instance.addedValue);
            Equipments.instance.armor.GetComponent<ArmorController>().isCharged = false;
            Equipments.instance.armor.GetComponent<ArmorController>().shieldTimer = 0;
        }
        else
        {
            health -= (zombieObject.GetComponent<Zombie>().biteDamage - (Equipments.instance.armor.GetComponent<ArmorController>().armorValue + this.baseArmor));
        }
        
        zombieObject.GetComponent<Zombie>().health -= Equipments.instance.armor.GetComponent<ArmorController>().armorDamage;
    }
    public void getShot(GameObject skillObject)
    {
        if (Equipments.instance.armor.GetComponent<ArmorController>().isCharged)
        {
            health -= (skillObject.GetComponent<BossSkill>().damage - (Equipments.instance.armor.GetComponent<ArmorController>().armorValue + this.baseArmor) - ArmorController.instance.addedValue);
            Equipments.instance.armor.GetComponent<ArmorController>().isCharged = false;
            Equipments.instance.armor.GetComponent<ArmorController>().shieldTimer = 0;
        }
        else
        {
            health -= (skillObject.GetComponent<BossSkill>().damage - (Equipments.instance.armor.GetComponent<ArmorController>().armorValue + this.baseArmor));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    
        if(collision.transform.tag == "ZB" && vulnerable)
        {
            Equipments.instance.armor.GetComponent<ArmorController>().isCharged = false;
            vulnerable = false;
            getBitten(collision.gameObject);
        }
    }
  
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DroppingItem"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ItemScriptable ISItem = (ItemScriptable) other.GetComponent<ItemDropper>().theChosenOne;
                if (ISItem.typeOfItem =="Gun")
                {
                    Weapons wp = (Weapons) ISItem;
                    WeaponController.instance.weapon = wp;
                }
                else if (ISItem.typeOfItem =="Hat")
                {
                    Hat hat = (Hat) ISItem;
                    HatController.instance.hat = hat;
                }
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "BossSkill" && vulnerable)
        {
            Equipments.instance.armor.GetComponent<ArmorController>().isCharged = false;
            vulnerable = false;
            getShot(collision.gameObject);
        }
    }

    private void StateSwitch()
    {
        if(!vulnerable)
        {
            state = State.hurt;

            if(isDead)
            {
                state = State.dead;
            }
        }
        
        else
        {
            state = State.normal;
        }
    }
    public void PullTrigger(Vector3 target, Vector3 difference, float rotationZ)
    {
        if (Equipments.instance.weapon!=null && WeaponController.instance.weapon!=null)
        {
            Equipments.instance.weapon.GetComponent<WeaponController>().Shoot(target, difference, rotationZ);
        }
        
        //WeaponController.instance.Shoot(target, difference, rotationZ);
    }
    public void PlantMine()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            GameObject mine = Instantiate(minePrefab) as GameObject;
            mine.transform.position = this.transform.position;
            mine.GetComponent<Mine>().planter = this.transform;
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            GameObject mine = Instantiate(minePrefab) as GameObject;
            mine.transform.position = this.transform.position;
            mine.GetComponent<Mine>().planter = this.transform;
        }
    }
    public void ToggleStatUI()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!statUI.activeInHierarchy)
            {
                statUI.SetActive(true);
            }
            else
            {
                statUI.SetActive(false);
            }
        }
    }
    public void GetPoint(int pointValue)
    {
        point += pointValue;
        pointCount.text = point.ToString();
    }




}
