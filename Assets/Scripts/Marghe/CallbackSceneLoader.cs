using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackSceneLoader : MonoBehaviour
{
    private bool isFirstUpdate = true;

    // Start is called before the first frame update
    // void Start()
    // {
    //     SceneLoader.LoaderCallback();
    // }


    //Chiama la funzione LoaderCallback() dopo il prima Update
    //assicurandosi che faccia almeno un Update prima di caricare la scena
    void Update()
    {
        if (isFirstUpdate)
        {
            SceneLoader.LoaderCallback();
            isFirstUpdate = false;
        }
    }
}
