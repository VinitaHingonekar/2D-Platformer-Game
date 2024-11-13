using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private BoxCollider2D playerCollider;

    private Rigidbody2D rigidBody;
    
    public float speed;
    public int jump;

    private bool isJumping = false; 

    private Vector2 colliderSize;
    private Vector2 colliderOffset;

    public ScoreController scoreController;

    private bool isGrounded;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        colliderSize = playerCollider.size;
        colliderOffset = playerCollider.offset;

        // Debug.Log("-Level 1: " + PlayerPrefs.GetInt("Level 1", -1));
        // Debug.Log("-Level 2: " + PlayerPrefs.GetInt("Level 2", -1));
        // Debug.Log("-Level 3: " + PlayerPrefs.GetInt("Level 3", -1));
        // Debug.Log("-Level 4: " + PlayerPrefs.GetInt("Level 4", -1));
        // Debug.Log("-Level 5: " + PlayerPrefs.GetInt("Level 5", -1));
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        // CROUCH
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }

        // JUMP

        if (isGrounded && isJumping)
        {
            isJumping = false;
        }
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        // Running
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Jumping
        if(vertical > 0 && isGrounded && !isJumping)
        {
            isJumping = true;
            animator.SetTrigger("Jump");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
        }
        // else if(isGrounded)
        // {
        //     isJumping = false;
        // }
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
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log("Is Grounded");
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log("Is not Grounded");
            isGrounded = false;
        }
    }

    public void KeyPickup()
    {
        Debug.Log("Key Picked Up");
        scoreController.IncreaseScore(50);
    }

    
    public void PlayDeathAnimation()
    {
        Debug.Log("Player Dead");
        animator.SetTrigger("Death");
    }
}
