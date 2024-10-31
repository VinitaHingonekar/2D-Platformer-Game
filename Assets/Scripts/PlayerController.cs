using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private BoxCollider2D playerCollider;
    
    public float speed;

    private Vector2 colliderSize;
    private Vector2 colliderOffset;

    private void Start()
    {
        colliderSize = playerCollider.size;
        colliderOffset = playerCollider.offset;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal);

        // CROUCH
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.1f;
            float offY = 0.58f;

            float sizeX = 0.68f;
            float sizeY = 1.34f;

            playerCollider.size = new Vector2(sizeX, sizeY);
            playerCollider.offset = new Vector2(offX, offY);
        }

        else
        {
            playerCollider.size = colliderSize;
            playerCollider.offset = colliderOffset;
        }

        animator.SetBool("Crouch", crouch);
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed" , Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if(horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // PlayJumpAnimation(vertical);
        if ( vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}


// 0.53, 1,2