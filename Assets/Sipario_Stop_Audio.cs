using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sipario_Stop_Audio : MonoBehaviour
{
   AudioSource aud;
   

   void Start(){
    aud = GetComponent<AudioSource>();
  }

   public void stop_sound()
   {
    aud.Stop();
   }
}
