using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Videoactive : MonoBehaviour
{
    public GameObject videoplayer;
    public int tts;
    public GameObject music;
    public GameObject boss;
    private bool firsttime;
    
    // Start is called before the first frame update
    void Start()
    {
        
        videoplayer.SetActive(false);
        firsttime = true;
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player")&&firsttime==true)
        {
            Debug.Log(":v");

            music.GetComponent<AudioSource>().volume=0;
            videoplayer.SetActive(true);
            Destroy(videoplayer, tts);
            
            StartCoroutine(Desactivatepls());
            firsttime = false;
        }
    }
    IEnumerator Desactivatepls()
    {
        
        yield return new WaitForSeconds(6f);
        boss.GetComponent<AudioSource>().volume = .4f;
    }
}
