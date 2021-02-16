using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    private Vector3 input;
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
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
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 velocity = input.normalized * Speed;
        transform.position += velocity * Time.deltaTime;
    }

    public void Dash()
    {
        if(direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
                Debug.Log(direction);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
                Debug.Log(direction);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
                Debug.Log(direction);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
                Debug.Log(direction);
            }         
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;                
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    Debug.Log("Dash");
                }
                else if (direction == 2 && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    Debug.Log("Dash");
                }
                else if (direction == 3 && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.up * dashSpeed;
                    Debug.Log("Dash");
                }
                else if (direction == 4 && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.down * dashSpeed;
                    Debug.Log("Dash");
                }
            }
        }
    }
}
