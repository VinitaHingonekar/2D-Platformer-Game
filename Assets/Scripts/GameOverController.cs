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
    }

    public void ReloadGame()
    {
        Debug.Log("Reloading scene");
        SceneManager.LoadScene(0);
        gameOverPanel.SetActive(false);
    }
}
