using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    private float startTimeBtwA;
    private float timeBtwA;
    [SerializeField]
    private int damage;
    [SerializeField]
    private bool boss;
    private HealthSystem healthsystem;
    // Start is called before the first frame update
    void Start()
    {
        healthsystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        timeBtwA = startTimeBtwA;
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwA -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (timeBtwA <= 0 && boss==false)
            {
                healthsystem.TakeDamage(damage);
                timeBtwA = startTimeBtwA;
            }
            else if(boss==true)
            {
                healthsystem.TakeDamage(damage);
            }
            
        }
    }
}
