using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Texts")]
    public Text scoreText;
    public Text bestScoreText;

    [Header("Score")]
    public int score;
    public int totalScore;

    [Header("Components")]
    public static GameController instance;
    public GameObject gameOverObj;
    public GameObject pauseObj;

    [Header("Checks")]
    private bool isPaused;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void UpdateScore(int kills)
    {
        score += kills;
        bestScoreText.text = "Best Score = "+totalScore.ToString();

        PlayerPrefs.SetInt("Score", totalScore);
    }

    public void UpdateKills(int kills)
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if(score > totalScore)
        {
            totalScore = score;
            UpdateScore(totalScore);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
