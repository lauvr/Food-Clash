using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusListener : MonoBehaviour
{
    public GameObject burnImage;

    public void BurnFeedback()
    {
        StopCoroutine(BurnImage());
        StartCoroutine(BurnImage());
    }

    IEnumerator BurnImage()
    {
        burnImage.SetActive(true);
        yield return new WaitForSeconds(3f);
        burnImage.SetActive(false);
    }
}
