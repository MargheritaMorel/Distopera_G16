using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPC))]
public class NCPinteraction : Interactable
{
    private NPC npc;

    // Use this for initialization
    void Start()
    {
        npc = gameObject.GetComponent<NPC>();

    }

    public override void Interact(GameObject caller)
    {
        npc.Press();
    }
}
