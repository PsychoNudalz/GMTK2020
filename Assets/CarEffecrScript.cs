using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffecrScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private ParticleSystem jamEffect;
    [SerializeField] private ParticleSystem driveEffect;
    [SerializeField] private bool driving = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //playDriveEffect();
    }

    public void playJam()
    {
        jamEffect.Play();
    }

    public void playDriveEffect()
    {
        if (!driveEffect.isPlaying && driving)
        {
            driveEffect.Play();
        }
    }

    public void setDriving(bool b)
    {
        driving = true;
        playDriveEffect();
    }
}
