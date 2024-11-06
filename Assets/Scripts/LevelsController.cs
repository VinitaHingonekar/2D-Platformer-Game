using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        string levelName = "Level " + level;
        SceneManager.LoadScene(levelName);
    }
}
