using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string Level1;
    public string[] Levels;

    public float delayTime = 1f; 

    void Awake()
    {
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
        if (!PlayerPrefs.HasKey(Levels[0]))
        {
            foreach (string level in Levels)
            {
                SetLevelStatus(level, LevelStatus.Locked);
            }
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }

        // if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        // {
        //     SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        // }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + " Status : " + levelStatus);
        PlayerPrefs.Save();
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);

        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }

    // public void LoadNextLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     SoundManager.Instance.Play(Sounds.LevelNew);
    // }

    // public IEnumerator LoadNextLevelWithDelay()
    // {
    //     yield return new WaitForSeconds(delayTime);

    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     SoundManager.Instance.Play(Sounds.LevelNew);
    // }

}