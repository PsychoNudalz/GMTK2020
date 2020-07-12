using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    public GameObject panel;
    public string lastLevel = "Level3";
    public Button nextButton;

    public TextMeshProUGUI title;
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI lapTimes;


    // Update is called once per frame
    void Update()
    {
        /*
        if (!lapTimer.IsRunning())
        {
            DisplayCompleteScreen(lapTimer.GetScoreStringArray(), lapTimer.GetHighScoreString());
        }
        */
    }

    public void DisplayCompleteScreen(string[] scores, string highScore, bool isHighScore)
    {
        
        if (isHighScore)
        {
            title.text = "New Highscore!";
        }
        else
        {
            title.text = "Level Complete!";
        }
        totalTime.text = "Total Time : " + scores[scores.Length-1];
        string times = "";
        for (int x = 0; x < (scores.Length - 1); x++)
        {
            times += string.Format("Lap {0} : {1}\n", x + 1, scores[x]);
        }
        
        lapTimes.text = times;
        bestTime.text = "Best Time : " + highScore;
        panel.gameObject.SetActive(true);
        Time.timeScale = 0f;

        if (SceneManager.GetActiveScene().name.Equals(lastLevel))
        {
            nextButton.gameObject.SetActive(false);
            
        }
    }
}
