using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettoScena : MonoBehaviour
{

    [SerializeField] private GameObject _oggettoScena;
    [SerializeField] public SnapPoint _snappoint;
    public bool _isPlaced = false;

    /*qui andranno messe anche 1 private checklist tipo
     * 1 variabile per vedere se oggetto in posizione corretta (es albero in snap1)
     * creare una funzione che metta il check nella checklist se oggetti posizionati
     * e dentro mettere anche un valore per dire quanti oggetti sono stati posizionati
     * correttamente
     * Tutto questo forse va messo negli snappoint??
     */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
