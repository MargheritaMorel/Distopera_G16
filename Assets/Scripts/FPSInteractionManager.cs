using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private Transform _holdArea;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private Menu _menu;

    [SerializeField] private Image _target;

    private int firstTimeVisualTabletUI = 0;


   // [SerializeField] private TestoTemporaneo _canvasTabletCompari;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;

    [Header("Sorgente Audio")]
    [SerializeField] private AudioSource audioGrab;
    [SerializeField] private AudioSource audioDrop;
    [SerializeField] private AudioSource tabletSound;
    [SerializeField] private AudioSource popUp;
    [SerializeField] private AudioSource popDown;
    
    


    [SerializeField] private List<SnapPoint> snapPoints;
    [SerializeField] private float snapRange = 2f;
    private OggettoScena _oggettoScena = null;

    [SerializeField] private FirstPersonCharacterController _fpsInventory;
    [SerializeField] private Tablet _tablet;

    private Rigidbody rb = null;
    private GameObject heldObj;

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
        StartSnapPoint(false, null);
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if(_grabbedObject == null)
            CheckInteraction();

        if (_grabbedObject != null)
            MoveObject();      

        if (_grabbedObject != null && Input.GetMouseButtonDown(0))
            Drop();

        if (Input.GetKeyDown("t") && _tablet.isTaken == true) 
        {
            if (_tablet.isOpen && firstTimeVisualTabletUI==0) { 
                Debug.Log("volte successive tablet visualizzato");
                _tablet.CloseCanvas();
                tabletSound.Play();
            }

            else if (_tablet.isOpen && firstTimeVisualTabletUI==1) { 
                Debug.Log("prima volta tablet visualizzato");
                _tablet.CloseCanvas();
                _tablet.OpenCanvasTask1();
                tabletSound.Play();
                firstTimeVisualTabletUI = 0;
            }
            
            else 
            {
                _tablet.OpenCanvas();
                tabletSound.Play();


            }
        }
        
        if (Input.GetKeyDown("m"))
        {
            if (_menu.isOpen)
            {
                _menu.CloseCanvas();
                popDown.Play();
            }
            else 
            {
                _menu.OpenCanvas();
                popUp.Play();
            }
        }

        UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable)
            { 
                if(Input.GetMouseButtonDown(0))
                    _pointingInteractable.Interact(gameObject);
            }

            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            _oggettoScena = hit.transform.GetComponent<OggettoScena>();

            if (_grabbedObject == null && _pointingGrabbable)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (_pointingGrabbable.tag == "Tablet" && _tablet.isTaken==false) Store(_pointingGrabbable);
                    else
                    {
                        _pointingGrabbable.Grab(gameObject);
                        if (_pointingGrabbable.tag == "OggettoScena")
                            GrabOggettoScena(_pointingGrabbable, _oggettoScena);
                        else
                            Grab(_pointingGrabbable);
                    }
                }
                    
            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
            _pointingGrabbable = null;
        }
    }

    private void UpdateUITarget()
    {
        if (_pointingInteractable)
            _target.color = Color.green;
        else if (_pointingGrabbable)
            if (_pointingGrabbable.tag == "Tablet") _target.color = Color.blue;
            else _target.color = Color.yellow;
        else
            _target.color = Color.red;
    }

    private void MoveObject()
    {
        if (Vector3.Distance(_grabbedObject.transform.position, _holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (_holdArea.position - _grabbedObject.transform.position);
            rb.AddForce(moveDirection * 150.0f);
        }
    }

    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        rb.useGravity = true;
        rb.drag = 1;
        rb.constraints = RigidbodyConstraints.None;
        //controllo se oggetto grabbato è un oggetto che va sul palco , magari con tag "oggettoPalco"
        
        if(audioDrop != null)
        {
            audioDrop.Play();
        }
        
        if (_grabbedObject.tag == "OggettoScena")
        {
            DropOggettoInScena(_grabbedObject, _oggettoScena);
        }
        _grabbedObject.Drop();
       
        _target.enabled = true;
        rb = null;
        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;

        if (_grabbedObject.GetComponent<Rigidbody>())
        {
            rb = _grabbedObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.drag = 10;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            grabbable.transform.SetParent(_holdArea);

        }
        _target.enabled = false;

        if (audioGrab != null)
        {
            audioGrab.Play();
        }
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }

    private void Store(Grabbable tablet)
    {
        tablet.transform.parent = _fpsInventory.transform;
        tablet.gameObject.SetActive(false);
        _tablet.isTaken=true;
        //_canvasTabletCompari.nowDisplay = true;
       // _canvasTabletCompari.OpenCanva();
        _tablet.OpenCanvas();
        firstTimeVisualTabletUI = 1;
    }

    private void GrabOggettoScena(Grabbable grabbable, OggettoScena oggetto)
    {
        if (oggetto._isPlaced == true)
        {
            if (oggetto._snappoint.isUsed == true)
            {
                _tablet.oggettoScenaPiazzato--;
                oggetto._snappoint.isUsed = false;
                oggetto._snappoint.gameObject.SetActive(true);
                oggetto._snappoint = null;
                oggetto.setFreedom();
            }
            oggetto._isPlaced = false;
        }
        StartSnapPoint(true, oggetto);
        Grab(grabbable);
    }

    private void StartSnapPoint(bool setUp, OggettoScena snap)
    {
        foreach (SnapPoint snapPoint in snapPoints)
        {
            if (snapPoint.isUsed == false && setUp)
            {
                snapPoint.gameObject.SetActive(true);
                if (snapPoint == snap._snappointCorretto) snapPoint.rightPosition = true;
                else snapPoint.rightPosition = false;
            }
            else snapPoint.gameObject.SetActive(false);
        }
    }

    //si può pensare di portare fuori questa funzione dall FPS controller
    private void DropOggettoInScena(Grabbable grabbable, OggettoScena oggetto)
    {
        float closestDistance = -1;
        SnapPoint closestSnapPoint = null;

        //magari ci possono essere 4 posizioni prestabilite sul palco, quindi cerco quello più vicino al blocco
        foreach (SnapPoint snapPoint in snapPoints)
        {
            if (!snapPoint.isUsed)
            {
                float currentDistance = Vector3.Distance(grabbable.transform.position, snapPoint.transform.position);

                if (closestSnapPoint == null || currentDistance < closestDistance)
                {
                    closestSnapPoint = snapPoint;
                    closestDistance = currentDistance;
                }
            }
        }

        //snapRange è il valore entro il quale il drop risulta "corretto"
        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            grabbable.transform.position = closestSnapPoint.transform.position;
            oggetto.setOriginalRotation();
            oggetto._isPlaced = true;
            oggetto._snappoint = closestSnapPoint;
            oggetto.setFreeze();
            oggetto._snappoint.isUsed = true;
            _tablet.oggettoScenaPiazzato++;
            _tablet.CheckOggettiScena();
            closestSnapPoint.gameObject.SetActive(false);

        }
        grabbable.Drop();


        StartSnapPoint(false, null);
    }
}
