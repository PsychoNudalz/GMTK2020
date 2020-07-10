using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform Vehicle;
    float speed = 50f;
    Dictionary<string, KeyCode> controlsMap = new Dictionary<string, KeyCode>();

    // Start is called before the first frame update
    void Start()
    {
        
        controlsMap.Add("Forward", KeyCode.W);
        controlsMap.Add("Backward", KeyCode.S);
        controlsMap.Add("Left", KeyCode.A);
        controlsMap.Add("Right", KeyCode.D);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(controlsMap["Forward"]))
        {
            Debug.Log("Forward");
            Vehicle.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
        }

        if (Input.GetKeyDown(controlsMap["Backward"]))
        {
            Debug.Log("Backward");
        }

        if (Input.GetKeyDown(controlsMap["Left"]))
        {
            Debug.Log("Left");
        }

        if (Input.GetKeyDown(controlsMap["Right"]))
        {
            Debug.Log("Right");
        }

    }
}
