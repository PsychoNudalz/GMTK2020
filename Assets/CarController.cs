using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed = 60f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float drift = 0.9f;

    Dictionary<string, KeyCode> controlsMap = new Dictionary<string, KeyCode>();
    private KeyCode[] keys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

    // Start is called before the first frame update
    void Start()
    {

        ResetControls();

    }
    
    // Update is called once per frame
    void Update()
    {

        Rigidbody2D car = GetComponent<Rigidbody2D>();

        car.velocity = ForwardVelocity() + SidewaysVelocity() * drift;

        //randomise controls on space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomiseControls();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetControls();
        }

        if (Input.GetKey(controlsMap["Forward"]))
        {
            Debug.Log("Forward");
            car.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
        }

        if (Input.GetKey(controlsMap["Backward"]))
        {
            Debug.Log("Backward");
            car.GetComponent<Rigidbody2D>().AddForce(transform.up * (speed * -1));


        }

        if (Input.GetKey(controlsMap["Left"]))
        {
            Debug.Log("Left");
            car.angularVelocity = 1 * turnSpeed;
        }

        if (Input.GetKey(controlsMap["Right"]))
        {
            Debug.Log("Right");
            car.angularVelocity = -1 * turnSpeed;
        }

        

        Vector2 ForwardVelocity()
        {
            return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
        }

        Vector2 SidewaysVelocity()
        {
            return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
        }

        void RandomiseControls()
        {
            //shuffle array
            for (int x = 0; x < keys.Length; x++)
            {
                KeyCode tmp = keys[x];
                int r = Random.Range(x, keys.Length);
                keys[x] = keys[r];
                keys[r] = tmp;
            }

            controlsMap = new Dictionary<string, KeyCode>();
            controlsMap.Add("Forward", keys[0]);
            controlsMap.Add("Backward", keys[1]);
            controlsMap.Add("Left", keys[2]);
            controlsMap.Add("Right", keys[3]);

        }
    }
    void ResetControls()
    {
        controlsMap = new Dictionary<string, KeyCode>();
        controlsMap.Add("Forward", KeyCode.W);
        controlsMap.Add("Backward", KeyCode.S);
        controlsMap.Add("Left", KeyCode.A);
        controlsMap.Add("Right", KeyCode.D);
    }
}
