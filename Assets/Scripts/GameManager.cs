using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool timerRunning;
    public bool gameOver = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI missedText;
    
    public Button restartButton;

    private float timerValue = 60;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if(timerRunning == true)
        {
            if(timerValue > 0)
            {
                timerValue -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.Round(timerValue);
            }

            else
            {
                timerValue = 0;
                gameOver = true;
            }
        }

        if(timerValue == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
}
