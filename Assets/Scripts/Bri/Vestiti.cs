using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class Vestiti : MonoBehaviour
{
    public Action OnButtonPressed;
    public Action OnButtonClosed;
    public bool isClicked = false;
    
    public UnityEvent evento;
    public UnityEvent evento1;

    [SerializeField] private Tablet _tablet;
   

    public void Press()
    {

        if (!isClicked)
        {
            if (OnButtonPressed != null)
                OnButtonPressed();
       
            evento.Invoke();
            isClicked = true;
            
        }
        else
        {
            if (OnButtonClosed != null)
                OnButtonClosed();
            evento1.Invoke();
            isClicked = false;
        }

    }

    public void VestitoBelleDan(){
        _tablet.vestitoVerificato ++;
         _tablet.CheckVestiti();
    }

}
