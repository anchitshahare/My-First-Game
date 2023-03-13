using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text score;
    private int scoreInt;
    public Text highScore;
    private int highScoreInt;
    public GameObject gameOverScreen;
    private bool _isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        if(PlayerPrefs.HasKey("highScore")) {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        }
        else {
            highScore.text = "High Score: " + 0;
        }
    }

    public void UpdateScore(int currentScore) {
        scoreInt = currentScore;
        score.text = currentScore.ToString();
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
        if(PlayerPrefs.HasKey("highScore")) {
            if(scoreInt > PlayerPrefs.GetInt("highScore")) {
                highScoreInt = scoreInt;
                highScore.text = "High Score: " + scoreInt;
                PlayerPrefs.SetInt("highScore", highScoreInt);
            } 
        } else {
            if(scoreInt > highScoreInt) {
                highScoreInt = scoreInt;
                highScore.text = "High Score: " + scoreInt;
                PlayerPrefs.SetInt("highScore", highScoreInt);
            } 
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        SceneManager.LoadScene(0);
    }
}
