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
    [SerializeField] private bool accesa = true;
    [SerializeField] private bool spenta = false;

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
            _faro.SetActive(spenta);
        }
        else
        {
            if (OnButtonClosed != null)
                OnButtonClosed();
            evento1.Invoke();
            isClicked = false;
            _faro.SetActive(accesa);
        }




    }
}
