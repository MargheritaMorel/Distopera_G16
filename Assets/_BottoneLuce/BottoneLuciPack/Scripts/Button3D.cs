using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Button3D : MonoBehaviour
{
    public Action OnButtonPressed;

    public Transform movingPieceT;
    public float localYFinalPressedPos;
    public float pressDuration = 0.3f;
    public float releaseDuration = 0.1f;

    public Color unpressedColor;
    public Color pressedColor;
    public Light _light;

    private MeshRenderer renderer;
    private bool isPressed = false;
    private float initialLocalYPos;
   


    void Start ()
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
            }));
        }
        else
        {
            pressSequence.Append(movingPieceT.DOLocalMoveY(initialLocalYPos, pressDuration).OnComplete(() =>
            {
                isPressed = false;
                if (OnButtonPressed != null)
                    OnButtonPressed();
                if (renderer != null)
                    renderer.material.color = unpressedColor;
                if (_light != null)
                    _light.gameObject.SetActive(false);
            }));
        }
    }
}
