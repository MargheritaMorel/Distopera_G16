using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimazioneSipario : MonoBehaviour
{
    public UnityEvent evento;

  

    public void SiparioAperto(){
        evento.Invoke();
    }



}
