using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    private Vector3 input;
    private Rigidbody2D rb;
    public float dashSpeed;
    private bool isDashing = false;
    public float dashDuration;
    private float dashDurationStart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false)

        {
            Speed += dashSpeed;
            isDashing = true;
            dashDurationStart = dashDuration;
        }
        if (dashDurationStart <= 0 && isDashing == true)
        {
            Speed -= dashSpeed;
            isDashing = false;
        }
        else
        {
            dashDurationStart -= Time.deltaTime;
        }

    }
}

