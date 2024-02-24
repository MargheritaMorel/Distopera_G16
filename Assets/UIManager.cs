using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    void OnEnable(){
        EnableUI();
    }

    void OnDisable(){
        DisableUI();
    }
    // Update is called once per frame
    void EnableUI()
    {
        FirstPersonCharacterController fps=FindObjectOfType<FirstPersonCharacterController>();
        if(fps!=null)
            fps.enabled=false;
        Cursor.lockState=CursorLockMode.None;
    }

    void DisableUI()
    {
        FirstPersonCharacterController fps=FindObjectOfType<FirstPersonCharacterController>();
        if(fps!=null)
            fps.enabled=true;
        Cursor.lockState=CursorLockMode.Locked;
    }
}
