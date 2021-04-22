using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Blinded : MonoBehaviour
{
    
    public Collider2D player;
    int currentDamage;

    public StatusListener feedback;

    UnityEvent onBlinded;
           

    private void Start()
    {
        feedback = GameObject.FindGameObjectWithTag("StatusEffect").GetComponent<StatusListener>();

        if (onBlinded == null)
            onBlinded = new UnityEvent();

        onBlinded.AddListener(ActivateStatusEffect);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            player = other;
            BlindPlayer();

            Debug.Log("Blinded!");

        }
    }

    public void BlindPlayer()
    {
        StopCoroutine(Blind());
        StartCoroutine(Blind());

    }

    public void ActivateStatusEffect()
    {

        feedback.BlindFeedback();
        Debug.Log("NO VEOOOO");
    }

    IEnumerator Blind()
    {
        if (onBlinded != null)
        {
            onBlinded.Invoke();
        }
        currentDamage = 20;
        HurtEnemy.damageToGive = 0;
        yield return new WaitForSeconds(3f);
        HurtEnemy.damageToGive = currentDamage;
    }
}
