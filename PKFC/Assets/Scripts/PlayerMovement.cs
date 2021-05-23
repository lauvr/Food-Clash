using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Inventory inv;
    public Joystick joystick;
    public Button dashButton;
    public Button attackButton;
    [SerializeField]
    private ParticleSystem movePS;
    [SerializeField]
    private ParticleSystem dashPS;

    [SerializeField]
    public float speed;


    private Vector3 input;
    private Rigidbody2D rb;
    public float dashSpeed;
    private bool isDashing = false;
    public float dashDuration;
    private float dashDurationStart;
    private float dashCooldown = 1.0f;
    private float nextDash;


    private float attackTime = 0.5f;
    public float attackCounter = 0.5f;
    private bool isAttacking;
    private float attackCooldown = 1.0f;
    private float nextAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

        Move();
        Dash();
        if (isAttacking)
        {
            rb.velocity = Vector3.zero;  //se supone que esto deberia hacer que no pueda moverse mientras ataca pero no funciona xd

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextAttack)
        {
            Attack();
            nextAttack = Time.time + attackCooldown;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            cinemachinechake.Instance.ShakeCamera(1.4f, .1f); // con solo esta linea de codigo ya se puede aplicar el shake de la camara, se le asigna primero la intensidad y luego la duracion
            //HealthSystem.Instance.TakeDamage(10);   //Me dio retraso y el jugador estaba recibiendo daño cuando atacaba al enemigo
        }
    }

    public void Move()
    {

#if UNITY_ANDROID
        float horizontal = joystick.Horizontal;                    
        float vertical = joystick.Vertical;
#else
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
#endif

        input = new Vector3(horizontal, vertical, 0);
        Vector3 velocity = input.normalized * speed;
        CreateDust();
        transform.position += velocity * Time.deltaTime;
        

        animator.SetFloat("moveX", horizontal);
        
        animator.SetFloat("moveY", vertical);
        CreateDust();

        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
        {
            
            animator.SetFloat("lastMoveX", horizontal);
            animator.SetFloat("lastMoveY", vertical);
        }


    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false && Time.time > nextDash)         //Dash PC
        {
            SoundManager.PlaySound("Player Dash");
            DashDust();
            speed += dashSpeed;
            isDashing = true;
            dashDurationStart = dashDuration;
            nextDash = Time.time + dashCooldown;
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

    public void PhoneDash()
    {
        if (isDashing == false)  //Dash Celular
        {
            SoundManager.PlaySound("Player Dash");
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

    void Attack()
    {
        SoundManager.PlaySound("Player Attack");

        attackCounter = attackTime;
        animator.SetBool("isAttacking", true);
        isAttacking = true;
        
    }

    public void PhoneAttack()
    {
        attackCounter = attackTime;
        animator.SetBool("isAttacking", true);
        isAttacking = true;

    }

    public void CreateDust()
    {
        movePS.Play();
    }
    public void DashDust()
    {
        dashPS.Play();
    }
}
