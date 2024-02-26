using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettoScena : MonoBehaviour
{

    [SerializeField] private GameObject _oggettoScena;
    [SerializeField] public SnapPoint _snappoint;
    [SerializeField] public SnapPoint _snappointCorretto;
    public bool _isPlaced = false;
    private Quaternion _originalRotation;
    private Vector3 _originalScale;

    // Start is called before the first frame update
    void Start()
    {
        _originalRotation = _oggettoScena.transform.rotation;
        _originalScale = _oggettoScena.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setOriginalRotation()
    {
        _oggettoScena.transform.rotation = _originalRotation;
        _oggettoScena.transform.localScale = _originalScale;
    }
}
