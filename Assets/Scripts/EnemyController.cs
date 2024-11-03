using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }

    [SerializeField] float moveSpeed = 1f;

    [SerializeField] Rigidbody2D rigidBody;
    public bool isFacingRight = true;

    void Update()
    {
        rigidBody.velocity = new Vector2 (moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;
        isFacingRight = !isFacingRight;
        FlipEnemySprite();  
    }

    private void FlipEnemySprite()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(rigidBody.velocity.x)), 1f);
    }
}
