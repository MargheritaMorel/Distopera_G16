using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class Presa : MonoBehaviour
{
    public Action OnButtonPressed;
    public Action OnButtonClosed;
    [SerializeField] private GameObject _faro;
  
    public bool isClicked = false;
    
    public UnityEvent evento;
    public UnityEvent evento1;
   
   
   
    void Start()
    {
        

    }

    public void Press()
    {

        if (!isClicked)
        {
            if (OnButtonPressed != null)
                OnButtonPressed();
       
        evento.Invoke();
            isClicked = true;
            _faro.SetActive(true);
        }
        else
        {
            if (OnButtonClosed != null)
                OnButtonClosed();
            evento1.Invoke();
            isClicked = false;
            _faro.SetActive(false);
        }




    }
}
