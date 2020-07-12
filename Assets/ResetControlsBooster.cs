using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetControlsBooster : MonoBehaviour
{
    public CarController player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.ResetControls();
            Destroy(gameObject);
        }
    }
}
