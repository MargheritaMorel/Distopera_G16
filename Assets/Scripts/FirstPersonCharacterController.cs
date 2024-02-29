using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstPersonCharacterController : MonoBehaviour
{
    
   
   [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _mouseSensitivity = 100f;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private GameObject _initialPosition;
    [SerializeField] private GameObject _player;  
   
   

    [Header("Footsteps parameters")]
    [SerializeField] float baseSpeed = 1.0f;
    [SerializeField] private AudioSource footstepAudioSource = default;
    [SerializeField] private AudioClip[] woodClips = default;
    [SerializeField] private AudioClip[] marbleClips = default;
    [SerializeField] private AudioClip[] moquetteClips = default;
    private float footstepTimer = 0;




    private CharacterController _characterController;
    private float cameraXRotation = 0f;
    private Vector3 _velocity;
    private bool _isGrounded;
    private string currentFloorTag = "";
    private Vector3 _actualPosition ;
    private Vector3 _pastPosition ;
    




    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        _player.transform.position = _initialPosition.transform.position;
        _actualPosition = _player.transform.position;


    }


    void Update()
    {
        _actualPosition = _player.transform.position;
        
        UpdateCursor();

        if(Cursor.lockState == CursorLockMode.None)
            return;

        //Ground Check
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(_groundCheck.position, Vector3.down, out hit, _groundDistance, _groundMask))
        {
            currentFloorTag = hit.collider.gameObject.tag;
        
        } 

        //Compute direction According to Camera Orientation
        transform.Rotate(Vector3.up, mouseX);
        cameraXRotation -= mouseY;
        cameraXRotation = Mathf.Clamp(cameraXRotation, -90f, 90f);
        _cameraT.localRotation = Quaternion.Euler(cameraXRotation, 0f, 0f);


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * h + transform.forward * v).normalized;
        _characterController.Move(move * _speed * Time.deltaTime);



       

        //JUMPING
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        //FALLING
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);

        //se posizione cambia, avvio il suono dei passi
        if (_actualPosition != _pastPosition)
        {
            _pastPosition = _actualPosition;
            PlayFootstepSound();
        }


        
    }

    private void UpdateCursor()
    {
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
            Cursor.lockState = CursorLockMode.Locked;

        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }

   
    
    private void PlayFootstepSound()
    {
       
        AudioClip[] clipsToPlay = null;

        footstepTimer -= Time.deltaTime;

       
        if (footstepTimer <= 0)
        {

            if (!string.IsNullOrEmpty(currentFloorTag))
            {
           
                switch (currentFloorTag)
                {
                    case "Footsteps/WOOD":
                        clipsToPlay = woodClips;
                        break;
                    case "Footsteps/MARBLE":
                        clipsToPlay = marbleClips;
                        break;
                    case "Footsteps/MOQUETTE":
                        clipsToPlay = moquetteClips;
                        break;

                            
                }

            if (clipsToPlay != null && clipsToPlay.Length > 0)
            {
                AudioClip clipToPlay = clipsToPlay[UnityEngine.Random.Range(0, clipsToPlay.Length)];
                footstepAudioSource.PlayOneShot(clipToPlay);
            }
            }
            footstepTimer = baseSpeed;
        }

    }
    



}
