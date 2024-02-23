using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarettoTurnOnButton : MonoBehaviour
{

    [SerializeField] private Button3D _turnLightButton;
    [SerializeField] private GameObject _faro;
    [SerializeField] AudioSource LightSwitchSound;
    //public GameObject txtToDisplay;

    [SerializeField] private Tablet _tablet;
    private bool _acceso = false;

    private FPSInteractionManager _fpscheck;


    void Start()
    {
        //txtToDisplay.SetActive(false);
        _turnLightButton.OnButtonPressed += OnLightOpenButtonPressed;
    }

    private void OnLightOpenButtonPressed()
    {
        _faro.SetActive(!_faro.activeSelf);
        if (_acceso == false)
        {
            _acceso = true;
            _tablet.luceAccesa++;
        }
        else { 
            _acceso = false;
            _tablet.luceAccesa--;
        }
        _tablet.CheckLuciAccese();
        LightSwitchSound.Play();
    }

    /*private void OnTriggerEnter(Collider Other)
    {

        if (Other.gameObject.tag == "Player")
        {
            txtToDisplay.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        txtToDisplay.SetActive(false);
    }*/
}
