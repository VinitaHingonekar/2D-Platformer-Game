using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private static int playerLives = 3;
    public int currentLives;

    [SerializeField] TextMeshProUGUI livesText;

    public float invincibilityDuration = 1.0f;
    // private float invincibilityTimer;
    public float blinkDuration = 0.1f;
    private bool isInvincible;

    public GameOverController gameOverController;

    private SpriteRenderer spriteRenderer;

    public ParticleSystem deathParticleSystem;

    public Image[] hearts;
    public Sprite fullHeart;

    private Animator[] heartAnimators;
    // public Sprite emptyHeart;
    

    private void Start() 
    {
        // livesText = GetComponent<TextMeshProUGUI>();
        currentLives = playerLives;
        UpdateLives();
        // invincibilityTimer = 0f;

        spriteRenderer = GetComponent<SpriteRenderer>();

        heartAnimators = new Animator[hearts.Length];
        for (int i = 0; i < hearts.Length; i++)
        {
            heartAnimators[i] = hearts[i].GetComponent<Animator>();
        }
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            // if(currentLives > 0)
            currentLives -= damage;
                
            Debug.Log("current lives : "+currentLives);
            UpdateLives();
            // invincibilityTimer = invincibilityDuration;

            if(currentLives == 0)
            {
                gameObject.GetComponent<PlayerController>().PlayDeathAnimation();
                // Death();
                SoundManager.Instance.Play(Sounds.PlayerDeath);
                if (deathParticleSystem != null)
                {
                    deathParticleSystem.Play();
                }
                this.enabled = false;
                Invoke("Death", 1.0f);
            }
            else if( currentLives < 0)
            {
                Debug.Log("LIves less than 0");
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
        Debug.Log("Started Coroutine invincibily");
        // float blinkInterval;

        while (elapsedTime < invincibilityDuration)
        {
            // Color color = spriteRenderer.color;
            // color.a = color.a == 1f ? 0.3f : 1f;
            // spriteRenderer.color = color;
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(blinkDuration);

            // spriteRenderer.enabled = true;

            elapsedTime += blinkDuration;
        }
                
        spriteRenderer.enabled = true;
        isInvincible = false;
    }

   

    private void Death()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Destroy(gameObject);
        // this.enabled = false;

        
        gameOverController.ShowGameOverScreen();
    }

    public void UpdateLives()
    {
        // if(currentLives < 0)
        // {
        //     livesText.text = "Lives : 0";
        // }
        // else 
        //     livesText.text = "Lives : " + currentLives;
        

        // foreach (Image img in hearts)
        // {
        //     img.sprite = emptyHeart;
        // }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                if (hearts[i].enabled == true)
                {
                    heartAnimators[i].SetTrigger("Lost");
                }

                // hearts[i].enabled = false;
            }
        }    
    }
}
