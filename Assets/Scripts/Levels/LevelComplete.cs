using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public ParticleSystem doorParticles;

    public LevelCompletePanel levelCompletePanel;

    public GameObject text;

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

                int level = SceneManager.GetActiveScene().buildIndex;
                int totalScenes = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
                
                if( level == totalScenes-2)
                {
                    StartCoroutine(LoadGameCompleteScene());
                }
                else
                {
                    StartCoroutine(levelCompletePanel.ShowGameCompleteScreen());         
                }   
            }
            else
            {
                text.SetActive(true);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {   
            text.SetActive(false);
        }
    }

    public IEnumerator LoadGameCompleteScene()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
