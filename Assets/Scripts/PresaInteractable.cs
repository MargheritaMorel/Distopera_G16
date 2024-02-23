using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Presa))]
public class PresaInteractable : Interactable
{
    private Presa button3D;

    // Use this for initialization
    void Start()
    {
        button3D = gameObject.GetComponent<Presa>();

    }

    public override void Interact(GameObject caller)
    {
        button3D.Press();
    }
}
