using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelCompletePanel : MonoBehaviour
{
    public ScoreController scoreController;
    public TextMeshProUGUI scoreText;

    private void Start() 
    {
        // scoreController = FindObjectOfType<ScoreController>();   
    }
    
    public void NextLevel(int level)
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        // string levelName = "Level " + level;
        // SceneManager.LoadScene(levelName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // levelsMenu.SetActive(true);
        // lobbyMenu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator ShowGameCompleteScreen()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(true);
        scoreText.text = "Score: " + scoreController.GetScore().ToString();
    }
}
