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
    }

    void OnEnable()
    {
        UpdateButtonStates();
    }

    public void UpdateButtonStates()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            LevelStatus status = LevelManager.Instance.GetLevelStatus(LevelManager.Instance.Levels[i]);

            if (status == LevelStatus.Unlocked || status == LevelStatus.Completed)
            {
                levelButtons[i].interactable = true;
                levelButtons[i].GetComponent<Image>().color = Color.white;
            }
            else if (status == LevelStatus.Locked)
            {
                levelButtons[i].interactable = false;
                levelButtons[i].GetComponent<Image>().color = Color.gray;  
                levelButtonTexts[i].color = Color.gray;

            }
        }
    }
}
