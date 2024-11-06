using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonLevels;

    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject lobbyMenu;
    
    private void Awake( )
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonQuit.onClick.AddListener(QuitGame);
        buttonLevels.onClick.AddListener(OpenLevelsMenu);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OpenLevelsMenu()
    {
        levelsMenu.SetActive(true);
        lobbyMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
