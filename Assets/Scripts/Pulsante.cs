using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;
public class Pulsante : MonoBehaviour
{
    public Action OnButtonPressed;

    public Transform movingPieceT;
    public float localYFinalPressedPos;
    public float pressDuration = 0.3f;
    public float releaseDuration = 0.1f;

    public Color unpressedColor;
    public Color pressedColor;
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

        renderer = movingPieceT.GetComponent<MeshRenderer>();
        if (renderer != null)
            renderer.material.color = unpressedColor;

    }

    public void Press()
    {
        if (isPressed)
            return;

        isPressed = true;
        if (renderer != null)
            renderer.material.color = pressedColor;

        Sequence pressSequence = DOTween.Sequence();
        pressSequence.Append(movingPieceT.DOLocalMoveY(localYFinalPressedPos, pressDuration).OnComplete(() =>
        {
            //When Button has reached the end of travel rise event
            if (OnButtonPressed != null)
                OnButtonPressed();
            _faro.SetActive(false);
        }));
        pressSequence.Append(movingPieceT.DOLocalMoveY(initialLocalYPos, releaseDuration));
        pressSequence.OnComplete(() =>
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
            }


            isPressed = false;
            if (renderer != null)
                renderer.material.color = unpressedColor;
        });
    }
}
