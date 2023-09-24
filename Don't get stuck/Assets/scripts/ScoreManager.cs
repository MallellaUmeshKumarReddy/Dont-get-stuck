using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static int score;
    private float timeInterval = 3f; // Time interval in seconds for score increment
    private int multipleOfTenReward = 3; // Points rewarded for every multiple of 10

    private bool paused = false;

    private float timer;

    private void Start()
    {
        score = 0;
        timer = 0f;
        UpdateScoreText();
    }

    private void Update()
    {
        // Update timer and check if it's time to increment the score
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            IncrementScore(1);
            timer = 0f;
        }

        // to pause 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else if (paused == true)
            {
                Time.timeScale = 1;
                paused = false;
            }
        }
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        // Check if the score is a multiple of 10 and reward additional points
        if (score % 10 == 0)
        {
            score += multipleOfTenReward;
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public static void SetScore(int value)
    {
        score = value;
    }

    public static int GetScore()
    {
        return score;
    }

    public void pause()
    {
        if (paused == false)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else if (paused == true)
        {
            Time.timeScale = 1;
            paused = false;
        }
    }
}