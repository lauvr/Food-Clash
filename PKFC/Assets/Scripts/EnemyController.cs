using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
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
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= maxRange && Vector2.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer(1);
            anim.SetBool("isMoving", true);  //si lo esta siguiendo activa la animacion de moviemiento
        }

        else if(Vector2.Distance(target.position, transform.position) < minRange && !meleeEnemy)
        {
            FollowPlayer(-1);
            
        }
        else
        {
            anim.SetBool("isMoving", false);  //si no lo sigue entra a idle
        }

    }

    public void FollowPlayer(float a)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, a*speed * Time.deltaTime);

    }
}
