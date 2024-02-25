using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_Sound : MonoBehaviour
{
   AudioSource aud_logo;
    void Start()
    {
       aud_logo = GetComponent<AudioSource>(); 
    }

    public void play_logo()
    {
        aud_logo.Play();
    }

    
}
