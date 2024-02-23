using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Faro : MonoBehaviour
{
    [SerializeField] public GameObject _faro;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SetActive()
    {
            _faro.SetActive(!_faro.activeSelf);
            //gameObject.GetComponent<AudioSource>().Play();
            //gameObject.GetComponent<Animator>.Play("switch");


    }
}
