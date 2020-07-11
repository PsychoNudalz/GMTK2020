using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int lapCounter = 0;
    public CheckpointScript[] checkpoints;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkCheckpoints())
        {
            lapCounter += 1;
            print(lapCounter);
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
