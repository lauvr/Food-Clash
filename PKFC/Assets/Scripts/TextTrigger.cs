using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopText;
    public GameObject enemyText;
    public GameObject instructionText;
    private PauseMenu pm;
    public GameObject tempEnemy;
    private bool firstTime = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("shopText"))
            {
                shopText.gameObject.SetActive(true);
                PauseGame();
            }
            if (CompareTag("enemyText"))
            {
                enemyText.gameObject.SetActive(true);
                if (firstTime == true)
                {
                    tempEnemy.SetActive(true);
                    firstTime = false;
                }
                PauseGame();
            }
            if (CompareTag("instructionText"))
            {
                instructionText.gameObject.SetActive(true);
                PauseGame();
            }
        }
    }
}


