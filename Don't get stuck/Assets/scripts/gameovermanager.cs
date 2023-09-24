using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameovermanager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Retrieve the score from the ScoreManager
        int score = ScoreManager.GetScore();

        // Display the score on the UI
        scoreText.text = "Score: " + score.ToString();
    }

    public void retry()
    {

        SceneManager.LoadScene(1);

    }

    public void exit()
    {
        Application.Quit();
        Debug.Log("im qutting");
    }
}
