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



    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
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
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
        if (currentHealth <= 0)
        {
            Instantiate(destroyeffect, transform.position, Quaternion.identity);
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


}
