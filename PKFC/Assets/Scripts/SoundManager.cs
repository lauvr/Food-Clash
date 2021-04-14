using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerAttack, playerDash, playerDeath;
    static AudioSource audioSrc;


    
    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("Player Attack");
        playerDash = Resources.Load<AudioClip>("Player Dash");
        playerDeath = Resources.Load<AudioClip>("Player Death");

        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Player Attack":
                audioSrc.PlayOneShot(playerAttack);
                break;

            case "Player Dash":
                audioSrc.PlayOneShot(playerDash);
                break;

            case "Player Death":
                audioSrc.PlayOneShot(playerDeath);
                break;


        }
    }

    
}
