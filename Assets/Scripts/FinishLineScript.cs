using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    public CheckpointScript[] checkpoints;
    public LapTimer lapTimer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkCheckpoints())
        {
            lapTimer.CompleteLap();
            clearCheckpoints();
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkCheckpoints()
    {
        bool clear = true;
        foreach (CheckpointScript c in checkpoints)
        {
            if (!c.Passed)
            {
                clear = false;
            }
        }

        return clear;
    }

    void clearCheckpoints()
    {
        foreach (CheckpointScript c in checkpoints)
        {
            c.Passed = false;
        }
    }
}
