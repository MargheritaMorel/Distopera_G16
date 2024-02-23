using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
     [SerializeField] private Canvas _menu;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCanvas()
    {
        _menu.gameObject.SetActive(true);
        isOpen = true;

    }

    public void CloseCanvas()
    {
        _menu.gameObject.SetActive(false);
        isOpen = false;
    }
}
