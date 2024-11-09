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

    private Vector2 colliderSize;
    private Vector2 colliderOffset;

    public ScoreController scoreController;

    private bool isGrounded;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        colliderSize = playerCollider.size;
        colliderOffset = playerCollider.offset;
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
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        // Running
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        // SoundManager.Instance.Play(Sounds.PlayerMove);
        // Debug.Log("Movings");

        // Jumping
        if(vertical > 0 && isGrounded)
        {
            // animator.SetTrigger("Jump");
            animator.SetBool("Jump", true);
            // rigidBody.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
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
