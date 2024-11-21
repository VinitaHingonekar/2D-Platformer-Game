using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject lobbyMenu;

    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene("Level 1");
    }

    public void OpenLevelsMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelsMenu.SetActive(true);
        lobbyMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }

}
