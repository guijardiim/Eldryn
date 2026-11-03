using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
    public float attackRange = 2;
    public float attackCoolDown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;
    
    private float attackCoolDownTimer;
    private EnemyState enemyState;
    private int facingDirection = -1; 
   
   
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {

        CheckForPlayer();

        if (attackCoolDownTimer > 0)
        {
            attackCoolDownTimer -= Time.deltaTime;
        }
        
        if (enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if(enemyState == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Chase()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= attackRange && attackCoolDownTimer <= 0)
        {
            attackCoolDownTimer = attackCoolDown;
            ChangeState(EnemyState.Attacking);
        }
        
        else if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();   
            }   
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void CheckForPlayer()
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits [0].transform;
        
                    // parei aki minuto 12:04 do enemyState attack state
        // if (collision.gameObject.CompareTag("Player"))
        // {
        //     if (player == null)
        //     {
        //     player = collision.transform;
        //     }
            
            ChangeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))  
        {
        rb.linearVelocity = Vector2.zero;
        
        ChangeState(EnemyState.Idle);
        }
    }
    private void ChangeState(EnemyState newState) 
    { 
        if (enemyState == EnemyState.Chasing)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);
        enemyState = newState; 

        anim.SetBool("IsIdle", newState == EnemyState.Idle); 
        anim.SetBool("IsChasing", newState == EnemyState.Chasing); 
        anim.SetBool("IsAttacking", newState == EnemyState.Attacking); 
    }

    public enum EnemyState
    {
        Idle, 
        Chasing,
        Attacking
    }







}
