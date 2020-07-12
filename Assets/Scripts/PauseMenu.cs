﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public LapTimer lapTimer;
    public PlayerState player;
    public TextMeshProUGUI totalTimeText;
    public TextMeshProUGUI timesText;
    public TextMeshProUGUI bestTimeText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            player.stopSounds();
            string[] times = lapTimer.GetScoreStringArray();

            string timesString = "";
            for (int x = 0; x < (times.Length - 1); x++)
            {
                timesString += string.Format("Lap {0} : {1}\n", x + 1, times[x]);
            }

            totalTimeText.text = "Total Time : " + times[times.Length - 1];
            timesText.text = timesString;
            bestTimeText.text = "Best Time : " + lapTimer.GetHighScoreString();
            
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}