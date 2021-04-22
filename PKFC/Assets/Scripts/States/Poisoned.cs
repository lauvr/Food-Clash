using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Poisoned : MonoBehaviour
{
   
    public PlayerMovement mov;
    public Collider2D player;
    public StatusListener feedback;

    UnityEvent onPoisoned;

    private void Start()
    {
        feedback = GameObject.FindGameObjectWithTag("StatusEffect").GetComponent<StatusListener>();

        if (onPoisoned == null)
            onPoisoned = new UnityEvent();

        onPoisoned.AddListener(ActivateStatusEffect);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Poisoned!");
            player = other;
            mov = player.GetComponent<PlayerMovement>();
            PoisonPlayer();

            

        }
    }

    public void PoisonPlayer()
    {
        StopCoroutine(Poison());
        StartCoroutine(Poison());
        
    }

    public void ActivateStatusEffect()
    {

        feedback.PoisonFeedback();

    }

    IEnumerator Poison()
    {
        if (onPoisoned != null)
        {
            onPoisoned.Invoke();
        }
        mov.speed -= 0.7f;
        yield return new WaitForSeconds(5f);
        mov.speed += 0.7f;
    }
}
