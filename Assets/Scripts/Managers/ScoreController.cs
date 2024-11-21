using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;

    private void Start()
    {
        UpdateScore();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }    

    public int GetScore()
    {
        return score;
    }
}
