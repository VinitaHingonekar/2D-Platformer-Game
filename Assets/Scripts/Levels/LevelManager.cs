using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string Level1;
    public string[] Levels;

    public float delayTime = 1f; // Time to wait before loading the next level

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + " Status : " + levelStatus);
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        // int nextSceneIndex = currentScene.buildIndex + 1;
        // Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        // SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);

        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }

        // UpdateButtonStates(); 
    }

    public void LoadNextLevel()
    {
        // if(SceneManager.GetActiveScene().name == Levels[Levels.Length - 1])
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.Instance.Play(Sounds.LevelNew);
        // Debug.Log("Levels[Levels.lenght] = " + Levels[Levels.Length - 1]);
    }

    public IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.Instance.Play(Sounds.LevelNew);
    }


}
