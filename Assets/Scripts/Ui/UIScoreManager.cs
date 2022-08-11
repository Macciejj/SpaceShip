using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreManager : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;
    public int Score { get { return score; } set { score = value; } }

    void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
