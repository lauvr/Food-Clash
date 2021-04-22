using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusListener : MonoBehaviour
{

    public GameObject burnImage;
    public GameObject blindImage;
    public GameObject poisonImage;
    [SerializeField] FlashImage greenImage = null;
    [SerializeField] FlashImage redImage = null;
    [SerializeField] FlashImage purpleImage = null;
    [SerializeField] Color _greenColor = Color.green;
    [SerializeField] Color _redColor = Color.red;
    [SerializeField] Color _purpleColor = Color.magenta;



    public void BurnFeedback()
    {
        StopCoroutine(BurnImage());
        StartCoroutine(BurnImage());
    }

    IEnumerator BurnImage()
    {
        redImage.StartFlash(1f, .3f, _redColor);
        burnImage.SetActive(true);
        yield return new WaitForSeconds(3f);
        burnImage.SetActive(false);
    }





    public void BlindFeedback()
    {
        StopCoroutine(BlindImage());
        StartCoroutine(BlindImage());
    }

    IEnumerator BlindImage()
    {
        purpleImage.StartFlash(1f, .3f, _purpleColor);
        blindImage.SetActive(true);
        yield return new WaitForSeconds(3f);
        blindImage.SetActive(false);
    }





    public void PoisonFeedback()
    {
        StopCoroutine(PoisonImage());
        StartCoroutine(PoisonImage());
    }

    IEnumerator PoisonImage()
    {
        greenImage.StartFlash(1f, .3f, _greenColor);
        poisonImage.SetActive(true);
        yield return new WaitForSeconds(3f);
        poisonImage.SetActive(false);
    }


}
