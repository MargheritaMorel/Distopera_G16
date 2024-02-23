using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestitiInteractable : Interactable
{
   private Vestiti vestito;

    // Use this for initialization
    void Start()
    {
        vestito = gameObject.GetComponent<Vestiti>();

    }

    public override void Interact(GameObject caller)
    {
        vestito.Press();
    }
}
