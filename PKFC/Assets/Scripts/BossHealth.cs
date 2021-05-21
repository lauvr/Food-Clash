using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    [SerializeField]
    private GameObject destroyeffect;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    public event EventHandler OnWinning;
    public event EventHandler<OnDamagetakenEventArgs> OnDamageTaken;
    public class OnDamagetakenEventArgs : EventArgs
    {
        public int health;
    }
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }




    public void HurtEnemy(int damageToGive)
    {
        Debug.Log("Damage boss");
        cinemachinechake.Instance.ShakeCamera(3f, .1f);
        currentHealth -= damageToGive;
        OnDamageTaken?.Invoke(this, new OnDamagetakenEventArgs { health=currentHealth});
        flashActive = true;
        flashCounter = flashLength;
        if (currentHealth <= 0)
        {
            OnWinning?.Invoke(this,EventArgs.Empty);
            cinemachinechake.Instance.ShakeCamera(4f, .1f);
            Instantiate(destroyeffect, transform.position, Quaternion.identity);
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
