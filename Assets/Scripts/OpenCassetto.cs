using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCassetto : Interactable
{
    [SerializeField] AudioSource OpenDrawer;
    [SerializeField] AudioSource CloseDrawer;

    private bool boxOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        boxOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;
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
        coroutineAllowed = false;
        if (!boxOpened)
        {
            for (float i = 0f; i <= 0.5f; i += 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - 0.1f,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            OpenDrawer.Play();
            boxOpened = true;
        }
        else
        {
            for (float i = 0.5f; i >= 0f; i -= 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 0.1f,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            transform.position = initialPosition;
            CloseDrawer.Play();
            boxOpened = false;
        }
        coroutineAllowed = true;
    }
}
