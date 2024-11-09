using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    private Rigidbody2D rb;
    private Transform currentPoint;

    [SerializeField] float moveSpeed = 1f;

    // [SerializeField] Rigidbody2D rigidBody;
    public bool isFacingRight = true;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }

    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            FlipEnemySprite();
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            FlipEnemySprite();
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }

    }

    // private void OnTriggerExit2D(Collider2D other) 
    // {
    //     moveSpeed = -moveSpeed;
    //     isFacingRight = !isFacingRight;
    //     FlipEnemySprite();  
    // }

    private void FlipEnemySprite()
    {
        transform.localScale = new Vector2 ((Mathf.Sign(rb.velocity.x)), 1f);
    }
}
