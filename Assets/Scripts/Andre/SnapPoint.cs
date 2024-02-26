using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    [SerializeField] private GameObject _snapPoint;
    public bool isUsed = false;
    public bool isPlaced = false;
    public bool rightPosition = false;
    private MeshRenderer renderer;
    //private Vector3 _originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        renderer = _snapPoint.GetComponentInChildren<MeshRenderer>();
        renderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (rightPosition)
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = Color.red;
        }
    }
}
