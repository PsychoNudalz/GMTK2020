using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    [SerializeField] PlayerState playerState;

    [SerializeField] private string modifierName;
    public string ModifierName { get => modifierName; set => modifierName = value; }
    
    [SerializeField] private float modifierValue;
    public float ModifierValue { get => modifierValue; set => modifierValue = value; }

    private void Awake()
    {
        if (playerState.Equals(null))
        {
            playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerState.addMaxSpeedMod(gameObject.GetComponent<SpeedModifier>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerState.removeMaxSpeedMod(gameObject.GetComponent<SpeedModifier>());

    }
}
