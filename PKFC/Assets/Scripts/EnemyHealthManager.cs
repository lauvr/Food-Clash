using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public GameObject drop;
    [SerializeField]
    private GameObject destroyeffect;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    public int damage;
    public HealthSystem pHealth;




    void Start()
    {
        pHealth= GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        enemySprite = GetComponent<SpriteRenderer>();
        damage = 10;
    }

    
    void Update()
    {
        if (flashActive)
        {
            Flash();
        }

        
    }



    public void HurtEnemy(int damageToGive)
    {
        cinemachinechake.Instance.ShakeCamera(3f, .1f);
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
        if (currentHealth <= 0)
        {
            cinemachinechake.Instance.ShakeCamera(4f, .1f);
            Instantiate(destroyeffect, transform.position, Quaternion.identity);
            SoundManager.PlaySound("EnemyDeath");
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Flash()
    {
        if (flashCounter > flashLength * .99f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else if (flashCounter > flashLength * .82f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
        }
        else if (flashCounter > flashLength * .66f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else if (flashCounter > flashLength * .49f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
        }
        else if (flashCounter > flashLength * .33f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else if (flashCounter > flashLength * .16f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
        }
        else if (flashCounter > 0f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            flashActive = false;
        }
        flashCounter -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pHealth.TakeDamage(damage);
        }
    }



}
