using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        // scoreText = GetComponent<TextMeshProUGUI>();
    }

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
}
