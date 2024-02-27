using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tablet : MonoBehaviour
{
    [SerializeField] private GameObject _tablet;

    [SerializeField] private Toggle _toggleTask1;
    [SerializeField] private Toggle _toggleTask2;
    [SerializeField] private Toggle _toggleTask3;
    [SerializeField] private TextMeshProUGUI _textTask1;
    [SerializeField] private TextMeshProUGUI _textTask2;
    [SerializeField] private TextMeshProUGUI _textTask3;
    [SerializeField] private TextMeshProUGUI _textTask4;

    [SerializeField] private Image panelTask1;
    [SerializeField] private Image panelTask2;
     [SerializeField] private Image panelTask3;
    

    [SerializeField] private Canvas _canvasTabletUI;


    [SerializeField] private Canvas _canvasTask1;
    [SerializeField] private Canvas _canvasTask2;
    [SerializeField] private Canvas _canvasTask3;
    [SerializeField] private Canvas _canvasTask4;

    public UnityEvent task1Scompare;
    public UnityEvent task2Scompare;
    public UnityEvent task3Scompare;


    public bool isOpen = false;
    public bool isTaken = false;
    public float oggettoScenaPiazzato;
    public float luceAccesa;
    public float vestitoVerificato;
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
            _textTask1.text = "SCENOGRAFIA 1/4";
        }
        if(oggettoScenaPiazzato == 2){
            _textTask1.text = "SCENOGRAFIA 2/4";
        }
        if(oggettoScenaPiazzato == 3){
            _textTask1.text = "SCENOGRAFIA 3/4";
        }
        if (oggettoScenaPiazzato == 4)
        {
            oggettiCompleto = true;
             _textTask1.text = "SCENOGRAFIA COMPLETATO 4/4";
             panelTask1 = panelTask1.GetComponent<Image>();
             panelTask1.color = UnityEngine.Color.green;
            _toggleTask1.isOn = true;
            _canvasTask2.gameObject.SetActive(true);
            task1Scompare.Invoke();
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
            _textTask2.text = "LUCI 1/3";
        }
        if(luceAccesa == 2){
            _textTask2.text = "LUCI 2/3";
        }
        if(luceAccesa == 3){
            _textTask2.text = "LUCI COMPLETATO 3/3";
             panelTask2 = panelTask2.GetComponent<Image>();
             panelTask2.color = UnityEngine.Color.green;
            _toggleTask2.isOn = true;
            _canvasTask3.gameObject.SetActive(true);
            _textTask3.gameObject.SetActive(true);
            task2Scompare.Invoke();
        }

        if (luceAccesa == 3) luciAccese = true;
    }

    public void CheckVestiti(){
        if(vestitoVerificato == 1){
            _textTask3.text = "VESTITI 1/2";
        }
        if(vestitoVerificato == 2){
            _textTask3.text = "VESTITI COMPLETATO 2/2";
             panelTask3 = panelTask3.GetComponent<Image>();
             panelTask3.color = UnityEngine.Color.green;
             _toggleTask3.isOn = true;
            _canvasTask4.gameObject.SetActive(true);
            _textTask4.gameObject.SetActive(true);
            task3Scompare.Invoke();
        }

    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
