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
   // [SerializeField]
    //private GameObject destroyeffect;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.x);
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
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
            Debug.Log("Trigger");
            DestroyProjectile();
        }
    } 
    void DestroyProjectile()
    {
        //Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
