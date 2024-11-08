using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private static int playerLives = 3;
    private int currentLives;

    [SerializeField] TextMeshProUGUI livesText;

    public float invincibilityDuration = 1.0f;
    // private float invincibilityTimer;
    public float blinkDuration = 0.1f;
    private bool isInvincible;

    public GameOverController gameOverController;

    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        // livesText = GetComponent<TextMeshProUGUI>();
        currentLives = playerLives;
        UpdateLives();
        // invincibilityTimer = 0f;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // if (invincibilityTimer > 0)
        // {
        //     invincibilityTimer -= Time.deltaTime;
        //     spriteRenderer.enabled = !spriteRenderer.enabled;
        // }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentLives -= damage;
            Debug.Log("current lives : "+currentLives);
            UpdateLives();
            // invincibilityTimer = invincibilityDuration;

            if(currentLives <= 0)
            {
                gameObject.GetComponent<PlayerController>().PlayDeathAnimation();
                // Death();
                Invoke("Death", 1.0f);
            }
            else
            {
                StartCoroutine(InvincibilityCoroutine());
            }
        }
    }
    
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        float elapsedTime = 0f;
        // float blinkInterval;

        while (elapsedTime < invincibilityDuration)
        {
            // Toggle the sprite renderer to create a blinking effect
            // spriteRenderer.enabled = !spriteRenderer.enabled;

            // Reduce alpha to make the player appear translucent
            Color color = spriteRenderer.color;
            color.a = color.a == 1f ? 0.3f : 1f;
            spriteRenderer.color = color;

            yield return new WaitForSeconds(blinkDuration);
            elapsedTime += blinkDuration;
        }
                
        spriteRenderer.enabled = true;
        isInvincible = false;
    }

   

    private void Death()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Destroy(gameObject);
        this.enabled = false;
        gameOverController.ShowGameOverScreen();
    }

    public void UpdateLives()
    {
        livesText.text = "Lives : " + currentLives;
    }    
}
