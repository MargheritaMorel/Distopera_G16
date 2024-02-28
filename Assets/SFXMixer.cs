using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer MixerGenerale;

    public void SetVolumeSFX(float sliderValue)
    {
        MixerGenerale.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }
   
    
        
    
}
