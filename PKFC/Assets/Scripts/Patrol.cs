using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float waitTime;
    [SerializeField]
    private float startWaitTime;
    
    [SerializeField]
    private Transform[] moveSpots;
    private int randomSpot;

    private Transform actualposition;
    private float previousPosition;
    private Animator anim;
    private bool moving;

    void Start()
    {
        moving = true;
        anim = GetComponent<Animator>();
        actualposition = GetComponent<Transform>();
        previousPosition = actualposition.position.y;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0,moveSpots.Length); 
    }

    
    void Update()
    {
        moving = true;
        actualposition = transform;
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        ChangeAnimations(actualposition,previousPosition,moving);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            moving = false;
            previousPosition = actualposition.position.y;
            ChangeAnimations(actualposition, previousPosition,moving);
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                  
            }
            else
            {

                waitTime -= Time.deltaTime;
            }
        }
    }
    void ChangeAnimations(Transform actualPosition,float previousPosition,bool moving)
    {
        if (previousPosition > actualPosition.position.y && moving==true)
        {
            anim.SetBool("movingUp", false);
            anim.SetBool("movingDown", true);
            anim.SetBool("moving", true);
        }
        else if (previousPosition < actualPosition.position.y && moving==true)
        {
            anim.SetBool("movingUp", true);
            anim.SetBool("movingDown", false);
            anim.SetBool("moving", true);
        }
        else if(previousPosition == actualPosition.position.y && moving==false){
            anim.SetBool("movingUp", false);
            anim.SetBool("movingDown", false);
            anim.SetBool("moving", false);
        }
            
        }
    }

