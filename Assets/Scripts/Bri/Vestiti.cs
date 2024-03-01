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
    
    public bool belle = false;
    public bool dan = false;

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

    public void VestitoDan(){
        dan = true;

        if(belle==false){
            _tablet.vestitoVerificato = 1;
        }
        if(belle==true){
            _tablet.vestitoVerificato = 2;
        }
         _tablet.CheckVestiti();
    }

    public void VestitoBelle(){
        belle = true;
        
        if(dan==false){
            _tablet.vestitoVerificato = 1;
        }
        if(dan==true){
            _tablet.vestitoVerificato = 2;
        }
         _tablet.CheckVestiti();
    }

}
