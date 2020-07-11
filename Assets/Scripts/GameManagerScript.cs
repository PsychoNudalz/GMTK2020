using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [Header("Player States")]
    public PlayerState playerState;
    public TextMeshProUGUI SpeedUI;
    public TextMeshProUGUI countdownTimer;
    public LapTimer laptimer;
    public CarController carController;

    private float maxTimer = 5f;
    private float timer;
    private bool timerRunning = true;
    [SerializeField] bool useCountdown = true;

    // Start is called before the first frame update
    void Start()
    {

        timer = maxTimer;
        
    }


    // Update is called once per frame
    void Update()
    {
        countdown();
        updateSpeedUI();

    }
    
    void countdown()
    {
        if (!useCountdown)
        {
            StartCoroutine(hideCountdownTimer(0f));
            carController.isRunning = true;
            laptimer.isRunning = true;
        }
        else if (timerRunning)
        {
            countdownTimer.enabled = true;
            if (timer >= 0)
            {
                timer -= 1 * Time.deltaTime;
                countdownTimer.text = timer.ToString("0");
            }
            if (timer < 0.5f)
            {
                countdownTimer.text = "GO!";
                carController.isRunning = true;
                laptimer.isRunning = true;
                laptimer.ResetCurrentTime();
                StartCoroutine(hideCountdownTimer(1.5f));
                timerRunning = false;
            }
        }
    }

    IEnumerator hideCountdownTimer(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        countdownTimer.enabled = false;

    }

    void updateSpeedUI()
    {
        SpeedUI.text = playerState.getSpeed().ToString("0");
    }
}
