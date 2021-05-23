using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Burned : MonoBehaviour
{
    public HealthSystem health;
    public Collider2D player;
    public StatusListener feedback;
    int critchance;



    public List<int> burnTickTimers = new List<int>();


    UnityEvent onBurned;

    private void Start()
    {
        feedback = GameObject.FindGameObjectWithTag("StatusEffect").GetComponent<StatusListener>();

        if (onBurned == null)
            onBurned = new UnityEvent();

        onBurned.AddListener(ActivateStatusEffect);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            critchance = Random.Range(0, 5);
            if (critchance == 3)
            {
                player = other;
                if (health == null)
                {
                    health = player.GetComponent<HealthSystem>();
                }
                BurnPlayer(4);

                Debug.Log("Burned!");
            }
            

        }
    }

    public void BurnPlayer(int ticks)
    {
        
            StopCoroutine(Burn());
            StartCoroutine(Burn());
       

    }

    public void ActivateStatusEffect()
    {
        
        feedback.BurnFeedback();

    }

    IEnumerator Burn()
    {
        if (onBurned != null)
        {
            onBurned.Invoke();
        }
        for (int i = 0; i < 4; i++)
        {
            health.hitPoint -= 2.5f;
            yield return new WaitForSeconds(.5f);

        }
        
    }
}
