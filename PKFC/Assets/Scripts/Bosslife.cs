using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bosslife : MonoBehaviour
{
    [SerializeField]
    private int bossh;
    private Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Slider>();
        healthbar.value = bossh;
        BossHealth bosshealth = GetComponent<BossHealth>();
        bosshealth.OnDamageTaken += Bosshealth_OnDamageTaken;
    }

    private void Bosshealth_OnDamageTaken(object sender, BossHealth.OnDamagetakenEventArgs e)
    {
        healthbar.value = e.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
