using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverScript : MonoBehaviour
{
    public ParticleSystem doorParticles; // Assign this in the Inspector

    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            // Debug.Log("Next Level");
            LevelManager.Instance.MarkCurrentLevelCompleted();
            // if()
            if (doorParticles != null)
            {
                doorParticles.Play();
            }

            // LevelManager.Instance.LoadNextLevel();   
            StartCoroutine(LevelManager.Instance.LoadNextLevelWithDelay());         
        }
    }
}
