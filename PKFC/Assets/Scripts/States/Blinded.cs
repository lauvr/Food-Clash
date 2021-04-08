using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinded : MonoBehaviour
{
    //public HurtEnemy hurtEnemy;
    public Collider2D player;
    public GameObject blindImage;
    int currentDamage;

    [SerializeField] FlashImage flashImage = null;
    [SerializeField] Color _newColor = Color.green;

    private void Awake()
    {
        //hurtEnemy = hurtEnemy.GetComponent<HurtEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            BlindPlayer();

            flashImage.StartFlash(1f, .3f, _newColor);

            Debug.Log("Blinded!");

        }
    }

    public void BlindPlayer()
    {
        StopCoroutine("Blind");
        StartCoroutine("Blind");

    }

    IEnumerator Blind()
    {
        currentDamage = 20;
        HurtEnemy.damageToGive = 0;
        blindImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        HurtEnemy.damageToGive = currentDamage;
        blindImage.SetActive(false);
    }
}
