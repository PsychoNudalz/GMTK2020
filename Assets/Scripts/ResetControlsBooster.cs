using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetControlsBooster : MonoBehaviour
{
    public CarController player;
    public AudioSource pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            player = collision.GetComponent<CarController>();
            player.ResetControls();
            pickup.Play();
            print("Playing");
            Destroy(gameObject);
        }
    }
}
