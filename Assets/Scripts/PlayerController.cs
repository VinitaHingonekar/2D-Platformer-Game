using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public BoxCollider2D playerCollider;

    public Vector2 originalCollider;
    public Vector2 crouchCollider;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed" , Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // JUMP
        float jump = Input.GetAxisRaw("Vertical");
        if(jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        // CROUCH
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            playerCollider.size = crouchCollider;
        }
        else
        {
            animator.SetBool("Crouch", false);
            playerCollider.size = originalCollider;
        }
    }
}


// 0.53, 1,2