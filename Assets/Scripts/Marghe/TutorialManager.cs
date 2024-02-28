using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    [SerializeField] private GameObject _wasdcanvas;
    [SerializeField] private GameObject _interactCanva;
    [SerializeField] private GameObject _grabCanva;

    [SerializeField] private GameObject _director;
    [SerializeField] private GameObject _tablet;


    void Awake()
    {
        // _director.GetComponent<BoxCollider>.enabled = false;
        // _tablet.SetActive(false);
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_tutorialCanvas.activeSelf == true)
        {
            StartCoroutine(WaitForSeconds(2));
            _wasdcanvas.SetActive(true);

            StartCoroutine(WaitForSeconds(6));
            _wasdcanvas.SetActive(false);
        }
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
