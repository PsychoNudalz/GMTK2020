using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapTimer : MonoBehaviour
{

    [Header("Time Loader")]
    [SerializeField] int lapCounter = 0;
    [SerializeField] private float startTime;
    [SerializeField] private float currentTime;
    private int numberOfLaps = 5;
    public TextMeshProUGUI TimeUI;
    public TextMeshProUGUI LapTimes;
    public TextMeshProUGUI CurrentLap;
    public TextMeshProUGUI LapNumber;

    private bool isRunnning = true;
    private float[] times;

    // Start is called before the first frame update
    void Start()
    {
        times = new float[numberOfLaps+1];
        LapNumber.text = ("Lap " + (lapCounter+1));
        LapTimes.text = "Lap " + (lapCounter + 1) + " : --.--";
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
            LapTimes.text = LapTimes.text.Substring(0, LapTimes.text.Length - 5) + string.Format("{0}\nLap {1} : --.--", times[lapCounter].ToString("0.00"), lapCounter + 2);
            lapCounter += 1;
            LapNumber.text = "Lap " + (lapCounter + 1);
            resetCurrentTime();

            //If is the last lap calculate and display total time.
            if(lapCounter == numberOfLaps)
            {
                isRunnning = false;
                float totalTime = 0;
                foreach (float time in times)
                {
                    totalTime += time;
                }
                times[lapCounter] = totalTime;
                LapTimes.text = LapTimes.text.Substring(0, LapTimes.text.Length - 13) + string.Format("Total Time : {0}", times[lapCounter].ToString("0.00"));
                CurrentLap.text = string.Format("Total Time : {0}", times[lapCounter].ToString("0.00"));
                TimeUI.text = string.Format("Total Time\n{0}", times[lapCounter].ToString("0.00"));
                LapNumber.text = "FINISHED!";
            }
        }
        
    }

    void updateTimeUI()
    {
        TimeUI.text = currentTime.ToString("0");
        CurrentLap.text = "Current Lap: " + currentTime.ToString("0.00");
    }

    void resetCurrentTime()
    {
        startTime = Time.time;
    }
}
