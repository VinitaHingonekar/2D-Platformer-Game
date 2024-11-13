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
    public float blinkDuration = 0.1f;
    private bool isInvincible;

    public GameOverController gameOverController;

    private SpriteRenderer spriteRenderer;

    public ParticleSystem deathParticleSystem;

    public Image[] hearts;
    public Sprite fullHeart;

    private Animator[] heartAnimators;

    private void Start() 
    {
        currentLives = playerLives;
        UpdateLives();

        spriteRenderer = GetComponent<SpriteRenderer>();

        heartAnimators = new Animator[hearts.Length];
        for (int i = 0; i < hearts.Length; i++)
        {
            heartAnimators[i] = hearts[i].GetComponent<Animator>();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentLives -= damage;
                
            Debug.Log("current lives : "+currentLives);
            UpdateLives();

            if(currentLives == 0)
            {
                gameObject.GetComponent<PlayerController>().PlayDeathAnimation();
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

        while (elapsedTime < invincibilityDuration)
        {
            // Color color = spriteRenderer.color;
            // color.a = color.a == 1f ? 0.3f : 1f;
            // spriteRenderer.color = color;
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(blinkDuration);

            elapsedTime += blinkDuration;
        }
                
        spriteRenderer.enabled = true;
        isInvincible = false;
    }

   

    private void Death()
    {
        gameOverController.ShowGameOverScreen();
    }

    public void UpdateLives()
    {
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
            }
        }    
    }
}
