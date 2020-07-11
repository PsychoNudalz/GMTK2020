using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] private bool passed;
    public bool willRandom;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private SpriteRenderer[] lights;

    public bool Passed { get => passed; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !passed)
        {
            passed = true;
            setLight();
            particleSystem.Play();
            print("Passed Checkpoint: " + transform.position);
            if (willRandom)
            {
                collision.gameObject.GetComponent<PlayerState>().randomiseControls();

            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void resetCheckpoint()
    {
        passed = false;
        setLight();
    }


    void setLight()
    {
        foreach (SpriteRenderer r in lights)
        {
            if (passed)
            {
                r.material.SetFloat("_ShiftValue", 1.1f);

            }
            else
            {
                r.material.SetFloat("_ShiftValue", -0.1f);

            }
        }
    }
}
