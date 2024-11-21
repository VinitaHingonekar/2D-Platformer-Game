using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null )
        {
            // other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Level Restart");
        }
    }
}
