using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public GameObject gameOverPanel;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(ReloadGame);
        Debug.Log("Restart button registered");
    }

    public void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        SoundManager.Instance.Play(Sounds.PlayerDeath);
    }

    public void ReloadGame()
    {
        // Debug.Log("Reloading scene");
        SceneManager.LoadScene("Level 1");
        gameOverPanel.SetActive(false);
    }

    public void ManinMenu()
    {
        SceneManager.LoadScene("Lobby");
        gameOverPanel.SetActive(false);
    }
}
