using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Texts")]
    public Text scoreText;

    [Header("Score")]
    public int score;
    public int totalScore;

    [Header("Components")]
    public static GameController instance;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int kills)
    {
        score += kills;
        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("Score", kills + totalScore);
    }

    public void UpdateKills(int kills)
    {
        scoreText.text = kills.ToString();
    }
}
