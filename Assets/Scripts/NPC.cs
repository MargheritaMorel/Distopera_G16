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
    private Animator _animator;

    public UnityEvent evento;
   // public UnityEvent evento1;
    // Start is called before the first frame update
    void Start()
    {
         _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
    }
    public void Press()
    {

        if (!isClicked)
        {
            if (OnButtonPressed != null)
                OnButtonPressed();
            isClicked = true;
            evento.Invoke();
            

        }
        else
        {
            //if (OnButtonClosed != null)
          //      OnButtonClosed();
           // evento1.Invoke();
            isClicked = false;

        }




    }
    private void UpdateAnimations()
    {
        _animator.SetBool("isClicked", isClicked);

       
    }
}
