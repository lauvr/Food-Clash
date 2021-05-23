using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour
{
    public HealthSystem health;
    public PlayerMovement mov;
    public Inventory inv;
    private EnemyHealthManager enemy;
    public Collider2D player;
    private HurtEnemy enemyHp;
    public bool isRunning;
    public ParticleSystem effect;
    public Transform effectSpawn;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = GetComponent<HurtEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void RedPotion()
    {
        if(inv.rpotion > 0)
        {
            if(health.hitPoint < health.maxHitPoint)
            {
                health.hitPoint += 15;
                SpawnEffect();
                inv.rpotion -= 1;
                SoundManager.PlaySound("PotionDrink");
            }
            else
            {
                health.hitPoint = health.maxHitPoint;
            }
            
        }
        else
        {
            Debug.Log("Get a potion first");
        }
        
    }
    
    public void UseBluePotion()
    {
        if (inv.bpotion > 0)
        {
            StartCoroutine("Bpotion");
            SpawnEffect();
            SoundManager.PlaySound("PotionDrink");
        }
        else
        {
            Debug.Log("Get a potion first");
        }
        
    }

    public void UseGreenPotion()
    {
        if (inv.gpotion > 0)
        {
            StartCoroutine("Gpotion");
            SpawnEffect();
            SoundManager.PlaySound("PotionDrink");
        }
        else
        {
            Debug.Log("Get a potion first");
        }
        
    }

    IEnumerator Bpotion()
    {
        inv.bpotion -= 1;
        player.enabled = false;
        yield return new WaitForSeconds(5f);
        player.enabled = true;
    }

    IEnumerator Gpotion()
    {
        isRunning = true;
        inv.gpotion -= 1;
        yield return new WaitForSeconds(5f);
        isRunning = false;
    }


    public void SpawnEffect()
    {
        Instantiate(effect, effectSpawn);
        //Destroy(gameObject);
    }
   
}
