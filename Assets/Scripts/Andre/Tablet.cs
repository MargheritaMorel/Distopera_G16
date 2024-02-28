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

    [Header("Sorgenti Audio")]
    [SerializeField] AudioSource avanzaTask;
    [SerializeField] AudioSource completoTask;
    [SerializeField] AudioSource nuovoTask;
    


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
    private bool vestitiOk = false;




    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckOggettiScena()
    {
        if(oggettoScenaPiazzato == 1){
            _textTask1.text = "SCENOGRAFIA 1/4";
            avanzaTask.Play();
        }
        if(oggettoScenaPiazzato == 2){
            _textTask1.text = "SCENOGRAFIA 2/4";
            avanzaTask.Play();
        }
        if(oggettoScenaPiazzato == 3){
            _textTask1.text = "SCENOGRAFIA 3/4";
            avanzaTask.Play();
        }
        if (oggettoScenaPiazzato == 4)
        {
            oggettiCompleto = true;
             _textTask1.text = "SCENOGRAFIA COMPLETATO 4/4";
             panelTask1 = panelTask1.GetComponent<Image>();
             panelTask1.color = UnityEngine.Color.green;
             completoTask.Play();
             task1Scompare.Invoke();
            _toggleTask1.isOn = true;
            _canvasTask2.gameObject.SetActive(true);
            nuovoTask.Play();
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
        if(luceAccesa == 1 &&  oggettiCompleto == true){
            _textTask2.text = "LUCI 1/3";
            avanzaTask.Play();
        }
        if(luceAccesa == 2 && oggettiCompleto == true){
            _textTask2.text = "LUCI 2/3";
            avanzaTask.Play();
            
        }
        if(luceAccesa == 3 && oggettiCompleto == true){
            _textTask2.text = "LUCI COMPLETATO 3/3";
             panelTask2 = panelTask2.GetComponent<Image>();
             _toggleTask2.isOn = true;
             panelTask2.color = UnityEngine.Color.green;
             completoTask.Play();
            task2Scompare.Invoke();
            _canvasTask3.gameObject.SetActive(true);
            _textTask3.gameObject.SetActive(true);
            nuovoTask.Play();
        }

        if (luceAccesa == 3) luciAccese = true;
    }

    public void CheckVestiti(){
        if(vestitoVerificato == 1  && luciAccese == true){
            _textTask3.text = "VESTITI 1/2";
            avanzaTask.Play();
        }
        if(vestitoVerificato == 2 && luciAccese == true){
            _textTask3.text = "VESTITI COMPLETATO 2/2";
             panelTask3 = panelTask3.GetComponent<Image>();
             panelTask3.color = UnityEngine.Color.green;
             _toggleTask3.isOn = true;
             completoTask.Play();
             task3Scompare.Invoke();
             nuovoTask.Play();
             _canvasTask4.gameObject.SetActive(true);
             _textTask4.gameObject.SetActive(true);
             vestitiOk = true;
            
        }

    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
