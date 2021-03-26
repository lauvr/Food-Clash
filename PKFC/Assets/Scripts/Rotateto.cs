using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateto : MonoBehaviour
{
    
    private Transform player;
    private Vector3 target;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target= new Vector3(player.position.x, player.position.y);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
