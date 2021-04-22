using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Burned : MonoBehaviour
{
    public HealthSystem health;
    public Collider2D player;
    //public GameObject burnImage;

    //[SerializeField] FlashImage flashImage = null;               NOTA: Comenté las lineas relacionadas con las imagenes (de flash y estado) 
    //[SerializeField] Color _newColor = Color.red;                ya que no deja poner la refencia en los prefabs. Hay que solucionar eso de otra manera :(

    public List<int> burnTickTimers = new List<int>();


    UnityEvent onBurned;

    private void Start()
    {
        if (onBurned == null)
            onBurned = new UnityEvent();

       // onBurned.AddListener(GetComponent<StatusListener>().BurnFeedback);
    }

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
        if (onBurned != null)
        {
            onBurned.Invoke();
        }

    }

    IEnumerator Burn()
    {
        for (int i = 0; i < 4; i++)
        {
            
            Debug.Log(i);
            //burnImage.SetActive(true);
            health.hitPoint -= 2.5f;
            yield return new WaitForSeconds(.5f);
            //burnImage.SetActive(false);

        }
        
        
    }
}
