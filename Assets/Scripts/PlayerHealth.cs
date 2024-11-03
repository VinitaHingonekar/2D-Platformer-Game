using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private static int playerLives = 3;
    private int currentLives;

    [SerializeField] TextMeshProUGUI livesText;

    public float invincibilityDuration = 50.0f;
    private float invincibilityTimer;

    private void Start() 
    {
        // livesText = GetComponent<TextMeshProUGUI>();
        currentLives = playerLives;
        UpdateLives();
        invincibilityTimer = 0f;
    }

    private void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        Debug.Log(invincibilityTimer);
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibilityTimer <= 0)
        {
            currentLives -= damage;
            Debug.Log("current lives : "+currentLives);
            UpdateLives();
            invincibilityTimer = invincibilityDuration;

            if(currentLives <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateLives()
    {
        livesText.text = "Lives : " + currentLives;
    }    
}
