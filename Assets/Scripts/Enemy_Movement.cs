using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
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
        if (enemyState == EnemyState.Chasing)
        {
            if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();   
            }   
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
            player = collision.transform;
            }
            
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
        enemyState = newState; 

        anim.SetBool("IsIdle", newState == EnemyState.Idle); 
        anim.SetBool("IsChasing", newState == EnemyState.Chasing); 
    }

    public enum EnemyState
    {
        Idle, 
        Chasing,
    }







}
