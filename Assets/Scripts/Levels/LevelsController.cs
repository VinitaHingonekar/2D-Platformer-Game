using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        string levelName = "Level " + level;
        Debug.Log(levelName);
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        SoundManager.Instance.Play(Sounds.ButtonClick);


        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }

    }
}
