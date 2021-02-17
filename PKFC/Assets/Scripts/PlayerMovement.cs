using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private float speed;


    private Vector3 input;
    private Rigidbody2D rb;
    public float dashSpeed;
    private bool isDashing = false;
    public float dashDuration;
    private float dashDurationStart;

    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            animator.SetBool("isMoving", true);
            Debug.Log("is moving");
        }
        else
        {
            animator.SetBool("isMoving", false);
            Debug.Log("is idle");

            //animator.SetFloat("idleX", rb.rotation);
            //animator.SetFloat("idleY", rb.rotation);

            //Aqui va la animacion de idle que no supe como poner ;c

        }

        Move();
        Dash();

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthSystem.Instance.TakeDamage(10);
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        
        isMoving = horizontal != 0 || vertical != 0;


        input = new Vector3(horizontal, vertical, 0);
        Vector3 velocity = input.normalized * speed;
        transform.position += velocity * Time.deltaTime;

        animator.SetFloat("moveX", horizontal);
        animator.SetFloat("moveY", vertical);






        //Lau cambió esto por si algo xd



    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false)

        {
            speed += dashSpeed;
            isDashing = true;
            dashDurationStart = dashDuration;
        }
        if (dashDurationStart <= 0 && isDashing == true)
        {
            speed -= dashSpeed;
            isDashing = false;
        }
        else
        {
            dashDurationStart -= Time.deltaTime;
        }

    }
}
