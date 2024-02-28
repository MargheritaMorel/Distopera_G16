using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer MixerGenerale;

    public void SetVolumeMusic(float sliderValue)
    {
        MixerGenerale.SetFloat("MUSIC", Mathf.Log10(sliderValue) * 20);
    }
   
    
        
    
}
