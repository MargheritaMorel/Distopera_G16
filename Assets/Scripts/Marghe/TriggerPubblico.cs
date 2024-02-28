using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPubblico : MonoBehaviour
{
    public GameObject NPCPublic;
    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("Player entered the Director's Room");
        NPCPublic.SetActive(true);
    }

    // private void OnTriggerStay (Collider other)
    // {
    //     Debug.Log("Player is within the Room");
    // }

    private void OnTriggerExit (Collider other)
    {
        Debug.Log("Player exited the Room");
        NPCPublic.SetActive(false);
    }
}
