using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
     [SerializeField] private Canvas _menu;
     [SerializeField] private Image _menuPanel;
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
        isOpen = true;
        _menu.gameObject.SetActive(true);
        _menuPanel.gameObject.SetActive(true);

    }

    public void CloseCanvas()
    {
        isOpen = false;
        _menuPanel.gameObject.SetActive(false);
         _menu.gameObject.SetActive(false);
    }
}
