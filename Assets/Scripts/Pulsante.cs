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

    public Color unpressedColor;
    public Color pressedColor;
    public Light _light;
    [SerializeField] private GameObject _faro;
    private MeshRenderer renderer;
    private bool isPressed = false;
    private bool isOpened = false;
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
            _faro.SetActive(false);
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

                _faro.SetActive(true);
                evento1.Invoke();
                isOpened = false;
                attore.SetActive(false);
                attrice.SetActive(false);
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
