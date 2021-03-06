﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    public ParticleSystem teleportPS;
    public Transform psSpawn;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TP());
            TeleportPS();
        }
    }

    IEnumerator TP()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
        
     
    }

    public void TeleportPS()
    {
        teleportPS.Play();
    }

}
