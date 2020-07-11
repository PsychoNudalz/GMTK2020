using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class LapTimer : MonoBehaviour
{

    [Header("Time Loader")]
    [SerializeField] int lapCounter = 0;
    [SerializeField] private float startTime;
    [SerializeField] private float currentTime;
    private int numberOfLaps = 5;
    public TextMeshProUGUI TimeUI;
    public TextMeshProUGUI LapNumber;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI LapTimes;
    public TextMeshProUGUI CurrentLap;
    

    private bool isRunnning = true;
    private bool highscore = false;
    public string LevelName = "Level-1";

    private float[] times;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("Highscore" + LevelName) == 0f)
        {
            PlayerPrefs.SetFloat("Highscore" + LevelName, 3599.999f);
        }
        times = new float[numberOfLaps+1];
        LapNumber.text = ("Lap " + (lapCounter+1));
        HighScore.text = "Best Time : " + FormatTime(PlayerPrefs.GetFloat("Highscore" + LevelName));
        LapTimes.text = "Lap " + (lapCounter + 1) + " : --:--:--";
        resetCurrentTime();

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunnning)
        {
            currentTime = Time.time - startTime;
            updateTimeUI();
        }
        //test lap complete
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Test Lap");
            CompleteLap();
        }
    }

    public void CompleteLap()
    {
        if (isRunnning)
        {
            times[lapCounter] = currentTime;
            LapTimes.text = LapTimes.text.Substring(0, LapTimes.text.Length - 9) + string.Format("{0}\nLap {1} : --:--:---", FormatTime(times[lapCounter]), lapCounter + 2);
            lapCounter += 1;
            LapNumber.text = "Lap " + (lapCounter + 1);
            resetCurrentTime();

            //If is the last lap calculate and display total time check for highscore.
            if(lapCounter == numberOfLaps)
            {
                isRunnning = false;
                float totalTime = 0;
                foreach (float time in times)
                {
                    totalTime += time;
                }
                times[lapCounter] = totalTime;
                LapTimes.text = LapTimes.text.Substring(0, LapTimes.text.Length - 17);
                CurrentLap.text = string.Format("Total Time : {0}", FormatTime(times[lapCounter]));
                TimeUI.text = string.Format("Total Time\n{0}", FormatTime( times[lapCounter]));
                LapNumber.text = "FINISHED!";
                CheckHighScore(totalTime);
            }
        }
        
    }

    bool CheckHighScore(float totalTime)
    {
        if (totalTime < PlayerPrefs.GetFloat("Highscore" + LevelName))
        {
            PlayerPrefs.SetFloat("Highscore" + LevelName, totalTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    void updateTimeUI()
    {
        TimeUI.text = currentTime.ToString("0");
        CurrentLap.text = "Current Lap: " + FormatTime(currentTime);
    }

    void resetCurrentTime()
    {
        startTime = Time.time;
    }
}
