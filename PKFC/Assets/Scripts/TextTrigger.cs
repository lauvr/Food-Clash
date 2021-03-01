using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("shopText"))
            {
                Debug.Log("This is the shop: In here you can trade your resources for various potions");
            }
            if (CompareTag("enemyText"))
            {
                Debug.Log("This is an enemy, it will follow you when you are close and they hurt a lot, this one is trapped so dont worry about it");
            }
            if (CompareTag("instructionText"))
            {
                Debug.Log("Use WASD to move, space to dash and LMB to attack");
            }
        }
    }
}
