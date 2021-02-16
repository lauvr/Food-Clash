using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private bool meleeEnemy;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= maxRange && Vector2.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer(1);
        }

        else if(Vector2.Distance(target.position, transform.position) < minRange && !meleeEnemy)
        {
            FollowPlayer(-1);
        }

    }

    public void FollowPlayer(float a)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, a*speed * Time.deltaTime);
    }
}
