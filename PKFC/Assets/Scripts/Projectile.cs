﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifetime;
    private Transform player;
    private Vector2 target;
    [SerializeField]
    private int damage;
    private int damagevariation;
    private HealthSystem healthsystem;
    [SerializeField]
    private GameObject destroyeffect;


    
    void Start()
    {
        damagevariation= Random.Range(0, 3);
        damage = damage + damagevariation;
        healthsystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.x);
        Invoke("DestroyProjectile", lifetime);
    }

    
    void FixedUpdate()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthsystem.TakeDamage(damage);
            DestroyProjectile();
        }
    } 
    void DestroyProjectile()
    {
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
