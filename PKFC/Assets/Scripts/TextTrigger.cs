using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopText;
    public GameObject enemyText;
    public GameObject instructionText;

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
                shopText.gameObject.SetActive(true);
            }
            if (CompareTag("enemyText"))
            {
                enemyText.gameObject.SetActive(true);
            }
            if (CompareTag("instructionText"))
            {
                instructionText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("shopText"))
            {
                shopText.gameObject.SetActive(false);
            }
            if (CompareTag("enemyText"))
            {
                enemyText.gameObject.SetActive(false);
            }
            if (CompareTag("instructionText"))
            {
                instructionText.gameObject.SetActive(false);
            }
        }
    }
}
