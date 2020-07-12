using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    public CarController player;
    public GameObject icon;
    public AudioSource pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<CarController>();
            print("Boosted!");
            StartCoroutine(increaseSpeed());
            pickup.Play();
            icon.SetActive(false);
        }
    }

    IEnumerator increaseSpeed()
    {
        float currentAccel = player.getAccel();
        player.setAccel(currentAccel * 1.5f);
        yield return new WaitForSeconds(3);
        print("reset to " + currentAccel);
        player.setAccel(currentAccel);
        Destroy(gameObject);

    }
}
