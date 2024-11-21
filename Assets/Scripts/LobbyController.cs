using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OpenLevelsMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
