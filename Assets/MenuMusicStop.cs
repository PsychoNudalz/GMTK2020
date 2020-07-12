using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicStop : MonoBehaviour
{
    private MenuMusicScript _instance;
    private void Awake()
    {
        _instance = GameObject.FindObjectOfType<MenuMusicScript>();
        _instance.StopMusic();
    }
    
    

}
