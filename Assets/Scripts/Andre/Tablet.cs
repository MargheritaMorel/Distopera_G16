using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour
{
    [SerializeField] private GameObject _tablet;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TextMeshProUGUI _textTask1;
    [SerializeField] private Image panelTask1;
    [SerializeField] private TextMeshProUGUI _textTask2;
    [SerializeField] private Image panelTask2;
    [SerializeField] private TextMeshProUGUI _textTask3;
    [SerializeField] private Toggle _toggle2;
    [SerializeField] private Canvas _canvasTabletUI;

    [SerializeField] private Canvas _canvasTask1;

    [SerializeField] private Canvas _canvasTask2;

    [SerializeField] private Canvas _canvasTask3;



    public bool isOpen = false;
    public bool isTaken = false;
    public float oggettoScenaPiazzato;
    public float luceAccesa;
    private float vestitoScelto;
    private bool oggettiCompleto = false;
    private bool luciAccese = false;




    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckOggettiScena()
    {
        if(oggettoScenaPiazzato == 1){
            _textTask1.text = "Task SCENOGRAFIA 1/4";
        }
        if(oggettoScenaPiazzato == 2){
            _textTask1.text = "Task SCENOGRAFIA 2/4";
        }
        if(oggettoScenaPiazzato == 3){
            _textTask1.text = "Task SCENOGRAFIA 3/4";
        }
        if (oggettoScenaPiazzato == 4)
        {
            oggettiCompleto = true;
             _textTask1.text = "TASK SCENOGRAFIA COMPLETATO 4/4";
             panelTask1 = panelTask1.GetComponent<Image>();
             panelTask1.color = UnityEngine.Color.green;
            _toggle.isOn = true;
            _canvasTask2.gameObject.SetActive(true);
        }
    }

    public void OpenCanvas()
    {
        _canvasTabletUI.gameObject.SetActive(true);
        isOpen = true;
        
    }

    public void OpenCanvasTask1(){
        _canvasTask1.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        _canvasTabletUI.gameObject.SetActive(false);
        isOpen = false;
    }

    public void CheckLuciAccese()
    {   
        if(luceAccesa == 1){
            _textTask2.text = "Task LUCI 1/3";
        }
        if(luceAccesa == 2){
            _textTask2.text = "Task LUCI 2/3";
        }
        if(luceAccesa == 3){
            _textTask2.text = "TASK LUCI COMPLETATO 3/3";
             panelTask2 = panelTask2.GetComponent<Image>();
             panelTask2.color = UnityEngine.Color.green;
            _toggle2.isOn = true;
            _canvasTask3.gameObject.SetActive(true);
            _textTask3.gameObject.SetActive(true);
        }

        if (luceAccesa == 3) luciAccese = true;
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
