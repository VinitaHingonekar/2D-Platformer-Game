using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverScript : MonoBehaviour
{
    public ParticleSystem doorParticles;

    private void Start() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            KeyManager keyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();

            if( keyManager.keysCollected == 3)
            {
                LevelManager.Instance.MarkCurrentLevelCompleted();
                if (doorParticles != null)
                {
                    doorParticles.Play();
                }

                StartCoroutine(LevelManager.Instance.LoadNextLevelWithDelay());         
            }
            else
            {
                Debug.Log("Collect all the keys");
            }
        }
    }
}
