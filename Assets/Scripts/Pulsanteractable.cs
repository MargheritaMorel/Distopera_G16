using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Pulsante))]
public class Pulsanteractable : Interactable
{
    private Pulsante button3D;

    // Use this for initialization
    void Start()
    {
        button3D = gameObject.GetComponent<Pulsante>();

    }

    public override void Interact(GameObject caller)
    {
        button3D.Press();
    }
}
