using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    /*
    [Header("Time Loader")]
    [SerializeField] private float startTime;
    [SerializeField] private float currentTime;
    public TextMeshProUGUI TimeUI;
    */
    [Header("Player States")]
    public PlayerState playerState;
    public TextMeshProUGUI SpeedUI;

    // Start is called before the first frame update
    void Start()
    {
        //startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currentTime = Time.time - startTime;
        updateTimeUI();
        */
        updateSpeedUI();

    }
    /*
    void updateTimeUI()
    {
        TimeUI.text = currentTime.ToString("0");
    }
    */
    void updateSpeedUI()
    {
        SpeedUI.text = playerState.getSpeed().ToString("0");
    }
}
