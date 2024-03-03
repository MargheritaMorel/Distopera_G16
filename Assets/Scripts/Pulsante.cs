using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
public class Pulsante : MonoBehaviour
{
    public Action OnButtonPressed;
    public GameObject attore;
    public GameObject attrice;
    public GameObject fari_platea;
    public GameObject luci_platea;

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
    public Animator _animator1;
    public Animator _animator2;
    public Animator _animator3;
    public Animator _animator4;
    public Animator _animator5;
    public Animator _animator6;
    public Animator _animator7;
    public Animator _animator8;
    public Animator _animator9;
    public Animator _animator10;

    public bool siparioChiuso = false;

    public Canvas canvasMenu;
    public Image _menuPanel;
    //public bool spettacoloFinito;

    void Start()
    {
        initialLocalYPos = movingPieceT.localPosition.y;
        unpressedColor.a = 0.6f;
        pressedColor.a = 0.95f;
        renderer = movingPieceT.GetComponent<MeshRenderer>();
        if (renderer != null)
            renderer.material.color = unpressedColor;
        currentTime = TimeAmount;

        //_animator = GetComponent<Animator>();
        //spettacoloFinito = false;
    }

    void Update()
    {
        //siparioChiuso = false;


        if (_esciAttori == true)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0 && _esciAttori == true)
            {
                fari_platea.SetActive(true);
                luci_platea.SetActive(true);
                attore.SetActive(false);
                attrice.SetActive(false);
                currentTime = TimeAmount;
                _esciAttori = false;
                siparioChiuso = true;
                _animator1.SetBool("siparioChiuso", siparioChiuso);
                _animator2.SetBool("siparioChiuso", siparioChiuso);
                _animator3.SetBool("siparioChiuso", siparioChiuso);
                _animator4.SetBool("siparioChiuso", siparioChiuso);
                _animator5.SetBool("siparioChiuso", siparioChiuso);
                _animator6.SetBool("siparioChiuso", siparioChiuso);
                _animator7.SetBool("siparioChiuso", siparioChiuso);
                _animator8.SetBool("siparioChiuso", siparioChiuso);
                _animator9.SetBool("siparioChiuso", siparioChiuso);
                _animator10.SetBool("siparioChiuso", siparioChiuso);

                //spettacoloFinito = true;
                canvasMenu.gameObject.SetActive(true);
                _menuPanel.gameObject.SetActive(true);

            }
        }

        //if(spettacoloFinito == true)
        //{
        //}
        

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
                fari_platea.SetActive(false);
                luci_platea.SetActive(false);
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
