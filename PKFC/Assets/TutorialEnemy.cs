using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialEnemy : MonoBehaviour
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
    private BarLogic bl;
    private float delta_health;
    public bool isdead = false;
    private PauseMenu pm;




    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        enemySprite = GetComponent<SpriteRenderer>();
        damage = 10;
        bl = this.GetComponent<BarLogic>();
        pm = GetComponent<PauseMenu>();

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
        //delta_health = 1f / damageToGive;
        //bl.UpdateBar(delta_health);
        cinemachinechake.Instance.ShakeCamera(3f, .1f);
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            isdead = true;
            cinemachinechake.Instance.ShakeCamera(4f, .1f);
            Instantiate(destroyeffect, transform.position, Quaternion.identity);
            SoundManager.PlaySound("EnemyDeath");
            Instantiate(drop, transform.position, Quaternion.identity);
            LoadLevelOne();
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
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 01");
    }
}
