using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsContoller : MonoBehaviour
{
    public Button[] levelButtons;
    public TextMeshProUGUI[] levelButtonTexts;

    private void Start() 
    {
        UpdateButtonStates();
        Debug.Log("Called Update Button States");
    }

    void OnEnable()
    {
        UpdateButtonStates();
        // Debug.Log("Level 1: " + PlayerPrefs.GetInt("Level 1", -1));
        // Debug.Log("Level 2: " + PlayerPrefs.GetInt("Level 2", -1));
        // Debug.Log("Level 3: " + PlayerPrefs.GetInt("Level 3", -1));
        // Debug.Log("Level 4: " + PlayerPrefs.GetInt("Level 4", -1));
        // Debug.Log("Level 5: " + PlayerPrefs.GetInt("Level 5", -1));

    }

    public void UpdateButtonStates()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            LevelStatus status = LevelManager.Instance.GetLevelStatus(LevelManager.Instance.Levels[i]);

            if (status == LevelStatus.Unlocked || status == LevelStatus.Completed)
            {
                // levelButtons[i].interactable = true;
                levelButtons[i].GetComponent<Image>().color = Color.white;
                // Change color to white or any color you prefer
            }
            else if (status == LevelStatus.Locked)
            {
                // levelButtons[i].interactable = false;
                levelButtons[i].GetComponent<Image>().color = Color.gray;  
                levelButtonTexts[i].color = Color.gray;

            }
        }
    }
}
