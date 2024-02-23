using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampada : MonoBehaviour
{
    public Presa presa;

    public Material colors;
    public Material colors1;
    private MeshRenderer renderer;
  

    // Use this for initialization
    void Start()
    {
        presa.OnButtonPressed += OnChangeColorButtonPressed;
        presa.OnButtonClosed += OnChangeColorButtonClosed;


        renderer = GetComponent<MeshRenderer>();

        
    }

    private void OnChangeColorButtonPressed()
    {
        if (renderer != null)
            renderer.sharedMaterial = colors;
    }
    private void OnChangeColorButtonClosed()
    {
        if (renderer != null)
            renderer.sharedMaterial = colors1;
    }




}
