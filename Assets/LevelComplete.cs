using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{

    public LapTimer lapTimer;

    public TextMeshProUGUI title;
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI lapTimes;


    // Update is called once per frame
    void Update()
    {
        if (lapTimer.IsRunning())
        {
            DisplayCompleteScreen(lapTimer.GetScoreStringArray(), lapTimer.GetHighScoreString());
        }
    }

    void DisplayCompleteScreen(string[] scores, string highScore)
    {
        if (lapTimer.IsHighScore())
        {
            title.text = "New Highscore!";
        }
        totalTime.text = scores[scores.Length];
    }
}
