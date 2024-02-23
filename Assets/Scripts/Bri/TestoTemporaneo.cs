using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestoTemporaneo : MonoBehaviour
{
   public float TimeAmount;
    public float currentTime;
    public bool nowDisplay = false;
    [SerializeField] private Canvas _testoAscomparsa;

    // Start is called before the first frame update
   void Start()
    {
        currentTime = TimeAmount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nowDisplay == true)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if (_testoAscomparsa.gameObject.activeSelf)
                {
                    _testoAscomparsa.gameObject.SetActive(false);
                    nowDisplay = false;
                }
                else
                {
                    _testoAscomparsa.gameObject.SetActive(true);
                }
                currentTime = TimeAmount;
            }

        }
    }
    public void OpenCanva()
    {
        if(nowDisplay== true)
        {
            _testoAscomparsa.gameObject.SetActive(true);
        }
    }
}
