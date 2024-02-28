using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;
public class Pulsante : MonoBehaviour
{
    public Action OnButtonPressed;
    public GameObject attore;
    public GameObject attrice;

    public Transform movingPieceT;
    public float localYFinalPressedPos;
    public float pressDuration = 0.3f;
    public float releaseDuration = 0.1f;

    public float TimeAmount;
    public float currentTime;

    public Color unpressedColor;
    public Color pressedColor;
    public Light _light;
    private MeshRenderer renderer;
    private bool isPressed = false;
    private bool isOpened = false;
    private bool _esciAttori = false;
    private float initialLocalYPos;
    public UnityEvent evento;
    public UnityEvent evento1;


    void Start()
    {
        initialLocalYPos = movingPieceT.localPosition.y;
        unpressedColor.a = 0.6f;
        pressedColor.a = 0.95f;
        renderer = movingPieceT.GetComponent<MeshRenderer>();
        if (renderer != null)
            renderer.material.color = unpressedColor;
        currentTime = TimeAmount;

    }

    void Update()
    {
        if (_esciAttori == true)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0 && _esciAttori == true)
            {
                attore.SetActive(false);
                attrice.SetActive(false);
                currentTime = TimeAmount;
                _esciAttori = false;
            }
        }
    }

    public void Press()
    {
        /*if (isPressed)
            return;

        isPressed = true;*/
        if (renderer != null)
            renderer.material.color = pressedColor;

        Sequence pressSequence = DOTween.Sequence();
        if (isPressed == false)
        {
            pressSequence.Append(movingPieceT.DOLocalMoveY(localYFinalPressedPos, pressDuration).OnComplete(() =>
            {
            //When Button has reached the end of travel rise event
            if (OnButtonPressed != null)
                OnButtonPressed();
            isPressed = true;
            if (_light != null)
                _light.gameObject.SetActive(true);
            attore.SetActive(true);
            attrice.SetActive(true);

                if (!isOpened)
                {
                    evento.Invoke();
                    isOpened = true;
                }
               /*else
                {
                    _faro.SetActive(true);
                    evento1.Invoke();
                    isOpened = false;
                    attore.SetActive(false);
                    attrice.SetActive(false);
                }*/
            }));
        }
        else
        {
            pressSequence.Append(movingPieceT.DOLocalMoveY(initialLocalYPos, pressDuration).OnComplete(() =>
            {

                evento1.Invoke();
                isOpened = false;
                _esciAttori = true;
                isPressed = false;
                if (OnButtonPressed != null)
                    OnButtonPressed();
                if (renderer != null)
                    renderer.material.color = unpressedColor;
                if (_light != null)
                    _light.gameObject.SetActive(false);
            }));
        }
        //pressSequence.Append(movingPieceT.DOLocalMoveY(initialLocalYPos, releaseDuration));
        /*pressSequence.OnComplete(() =>
        {
            
            if (!isOpened)
            {
                evento.Invoke();
                isOpened = true;
            }
            else
            {
                _faro.SetActive(true);
                evento1.Invoke();
                isOpened = false;
                attore.SetActive(false);
                attrice.SetActive(false);
            }


            isPressed = false;
            if (renderer != null)
                renderer.material.color = unpressedColor;
        });*/
    }
}
