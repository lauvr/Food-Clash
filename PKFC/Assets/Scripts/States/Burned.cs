using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burned : MonoBehaviour
{
    public HealthSystem health;
    public Collider2D player;
    public GameObject burnImage;

    [SerializeField] FlashImage flashImage = null;
    [SerializeField] Color _newColor = Color.red;

    public List<int> burnTickTimers = new List<int>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other;
            health = player.GetComponent<HealthSystem>();
            BurnPlayer(4);

            //flashImage.StartFlash(1f, .3f, _newColor);

            Debug.Log("Burned!");

        }
    }

    public void BurnPlayer(int ticks)
    {
        
            StopCoroutine(Burn());
            StartCoroutine(Burn());
        
    }

    IEnumerator Burn()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(i);
            health.hitPoint -= 2.5f;
            yield return new WaitForSeconds(.5f);

        }
        //burnImage.SetActive(true);
        //burnImage.SetActive(false);
    }
}
