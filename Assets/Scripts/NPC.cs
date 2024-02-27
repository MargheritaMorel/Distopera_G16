using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NPC : MonoBehaviour
{
    public Action OnButtonPressed;
    public Action OnButtonClosed;
    public float TimeAmount;
    public Transform _character;
    public float currentTime;
    public bool isClicked = false;
    private Animator _animator;
    public Transform _lookObj;
    private Quaternion initialposition;
    public UnityEvent evento;
    //private float initialLocalYPos;
    //public Transform movingPieceT;
    // public UnityEvent evento1;
    // Start is called before the first frame update
    void Start()
    {
        //initialLocalYPos = movingPieceT.localPosition.y;
         initialposition = _character.rotation;
       
        currentTime = TimeAmount;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            if (_lookObj != null)
            {
            Vector3 newtarget = _lookObj.position;
            newtarget.y = transform.position.y;
            transform.LookAt(newtarget);
            }

            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                isClicked = false;
                _animator.SetBool("isClicked", isClicked);
                currentTime = TimeAmount;


                _character.rotation = initialposition;
            }

        }


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
