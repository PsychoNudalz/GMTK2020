using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] private bool passed;

    public bool Passed { get => passed; set => passed = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        passed = true;
        print("Passed Checkpoint: " + transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
