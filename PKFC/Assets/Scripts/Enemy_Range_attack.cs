using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range_attack : MonoBehaviour
{
    private float timeBtwShots;
    [SerializeField]
    private float starTimeBtwShots;
    [SerializeField]
    private GameObject projectile;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = starTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
