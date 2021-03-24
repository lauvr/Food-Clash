using System.Collections;
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
    [SerializeField]
    private bool moreChallenge;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        damagevariation = Random.Range(0, 3);
        damage = damage + damagevariation;
        healthsystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        target = new Vector2(player.position.x, player.position.y);
        Invoke("DestroyProjectile", lifetime);
    }

    
    void Update()
    {

        ProjectileMovement(moreChallenge);
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
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
    public void ProjectileMovement(bool challenge)
    {
        
        if (challenge == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (transform.position.x == player.position.x && transform.position.y == player.position.y)
            {
                DestroyProjectile();
            }
        }

    }
}
