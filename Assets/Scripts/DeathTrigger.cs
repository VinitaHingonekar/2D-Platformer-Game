using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    private Vector2 startPoint;
    public PlayerController player;

    private void Start() 
    {
        // PlayerController player = GetComponent<PlayerController>();
        startPoint = player.transform.position;  
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if( other.gameObject.GetComponent<PlayerController>() != null )
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            if(other.gameObject.GetComponent<PlayerHealth>().currentLives > 0)
            {
                other.transform.position = startPoint;
            }
            else
            {
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                // rb.gravityScale = 0;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("Level Restart");
        }
    }
}
