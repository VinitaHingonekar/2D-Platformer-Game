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

    public void UpdateButtonStates()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            LevelStatus status = LevelManager.Instance.GetLevelStatus(LevelManager.Instance.Levels[i]);

            if (status == LevelStatus.Unlocked || status == LevelStatus.Completed)
            {
                levelButtons[i].interactable = true;  // Make button clickable
                levelButtons[i].GetComponent<Image>().color = Color.white;
                // Change color to white or any color you prefer
            }
            else if (status == LevelStatus.Locked)
            {
                levelButtons[i].interactable = false;  // Disable the button
                levelButtons[i].GetComponent<Image>().color = Color.gray;  // Gray out the button for locked levels
                levelButtonTexts[i].color = Color.gray;

            }
        }
    }
}
