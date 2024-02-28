using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarettoSegui : MonoBehaviour
{
    public Transform _lookObj;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_lookObj != null)
        {

            transform.LookAt(_lookObj);
        }
    }
}
