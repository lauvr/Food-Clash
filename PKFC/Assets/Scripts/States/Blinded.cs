using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinded : MonoBehaviour
{
    //public HurtEnemy hurtEnemy;
    public Collider2D player;
    //public GameObject blindImage;
    int currentDamage;

    //[SerializeField] FlashImage flashImage = null;              NOTA: Comenté las lineas relacionadas con las imagenes (de flash y estado) 
    //[SerializeField] Color _newColor = Color.green;             ya que no deja poner la refencia en los prefabs. Hay que solucionar eso de otra manera :(

    private void Awake()
    {
        //hurtEnemy = hurtEnemy.GetComponent<HurtEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            player = other;
            BlindPlayer();

            //flashImage.StartFlash(1f, .3f, _newColor);

            Debug.Log("Blinded!");

        }
    }

    public void BlindPlayer()
    {
        StopCoroutine(Blind());
        StartCoroutine(Blind());

    }

    IEnumerator Blind()
    {
        currentDamage = 20;
        HurtEnemy.damageToGive = 0;
        //blindImage.SetActive(true);
        yield return new WaitForSeconds(3f);
        HurtEnemy.damageToGive = currentDamage;
        //blindImage.SetActive(false);
    }
}
