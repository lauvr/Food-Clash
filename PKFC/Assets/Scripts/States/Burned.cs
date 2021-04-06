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
            BurnPlayer(4);

            Debug.Log("Burned!");

        }
    }

    public void BurnPlayer(int ticks)
    {
        if (burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }

    IEnumerator Burn()
    {
        while (burnTickTimers.Count > 0)
        {
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            health.lasaluddeljugador -= 5;  //CHELO AYUDA POR FAVOR
            burnTickTimers.RemoveAll(i => i == 0);

            yield return new WaitForSeconds(0.75f);
;       }
    }
}
