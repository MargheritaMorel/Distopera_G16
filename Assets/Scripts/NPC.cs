using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NPC : MonoBehaviour
{
    public Action OnButtonPressed;
    public Action OnButtonClosed;

    public bool isClicked = false;

    public UnityEvent evento;
   // public UnityEvent evento1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            
        }
        else
        {
            //if (OnButtonClosed != null)
          //      OnButtonClosed();
           // evento1.Invoke();
            isClicked = false;

        }




    }
}
