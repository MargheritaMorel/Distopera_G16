using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject wasdCanvas;
    public GameObject interactCanvas;
    public GameObject grabCanvas;

    public GameObject tablet;
    public GameObject director;
    public GameObject door;

    private float timePassed;

    private void Update() 
    {
        //Disattiva il canva WASD
        timePassed += Time.deltaTime;
        if(timePassed > 5)
        {
            wasdCanvas.SetActive(false);
            //Debug.Log("Canvas WASD disattivato");
        }

        //Attiva il canva INTERACT
        if(timePassed > 8)
        {
            interactCanvas.SetActive(true);
            //Debug.Log("Canvas Interact attivato");
        }

        //Disattiva in canva INTERACT
        if(timePassed > 18)
        {
            interactCanvas.SetActive(false);
            //Debug.Log("Canvas Interact disattivato");
        }

        //Attiva il canva GRAB
        if(timePassed > 20)
        {
            grabCanvas.SetActive(true);
            //Debug.Log("Canvas Grab attivato");
        }

        //Disattiva il canva GRAB
        if(timePassed > 30)
        {
            grabCanvas.SetActive(false);
            //Debug.Log("Canvas GRab disattivato");
        }

        if(timePassed > 31)
        {
            director.GetComponent<BoxCollider>().enabled = true;
            door.GetComponent<BoxCollider>().isTrigger = true;
        }        
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("FPS entered the tutorial trigger");   

        wasdCanvas.SetActive(true);
        tablet.SetActive(false);
        director.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<BoxCollider>().isTrigger = false;
    }
}