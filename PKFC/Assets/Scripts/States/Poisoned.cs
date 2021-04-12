﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poisoned : MonoBehaviour
{
   
    public PlayerMovement mov;
    public Collider2D player;
    //public GameObject poisonImage;

    //[SerializeField] FlashImage flashImage = null;              NOTA: Comenté las lineas relacionadas con las imagenes (de flash y estado) 
    //[SerializeField] Color _newColor = Color.green;             ya que no deja poner la refencia en los prefabs. Hay que solucionar eso de otra manera :(


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other;
            mov = player.GetComponent<PlayerMovement>();
            PoisonPlayer();

            //flashImage.StartFlash(1f, .3f, _newColor);

            Debug.Log("Poisoned!");

        }
    }

    public void PoisonPlayer()
    {
        StopCoroutine(Poison());
        StartCoroutine(Poison());
        
    }

    IEnumerator Poison()
    {
        mov.speed -= 0.7f;
        //poisonImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        mov.speed += 0.7f;
        //poisonImage.SetActive(false);
    }
}
