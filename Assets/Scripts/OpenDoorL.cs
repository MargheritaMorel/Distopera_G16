using System.Collections;
using UnityEngine;



public class OpenDoorL : Interactable
{
    [SerializeField] AudioSource openAudioL;
    [SerializeField] AudioSource closeAudioL;

    private bool doorOpened;
    //private bool coroutineAllowed;
    [SerializeField] private float _angolo = 80f;

    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
        //coroutineAllowed = true;
    }

    private void OnMouseDown()
    {
        Invoke("RunCoroutine", 0f);
    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenThatDoor");
    }
    public override void Interact(GameObject caller)
    {
        OpenThatDoor();
    }

    private IEnumerator OpenThatDoor()
    {
        //coroutineAllowed = false;
        if (!doorOpened)
        {
            openAudioL.Play();
            
            for (float i = 0f; i <= _angolo; i += 3f)
            {
                transform.localRotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = true;
           
        }
        else
        {
            closeAudioL.Play();
            for (float i = _angolo; i >= 0f; i -= 3f)
            {
                transform.localRotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = false;
            
        }
        //coroutineAllowed = true;
    }
}
