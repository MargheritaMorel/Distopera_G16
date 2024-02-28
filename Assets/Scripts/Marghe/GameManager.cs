using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject _loadingScreen;
    [SerializeField] CanvasGroup _canvasGroupLoading;


    public SceneLoader.Scene currentScene;

    public GameObject _player;

    private bool _tutorialIsDone = false;
    public TutorialManager tutorialManager;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //currentScene = SceneLoader.Scene.Menu;

    }
    
    //This function is called when the object becomes enabled and active to load the scene
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(_canvasGroupLoading.gameObject);
        //_player.GetComponent<FirstPersonCharacterController>().enabled = true;
    }

    void Update()
    {
        //Carica la scena del gioco quando si preme il tasto spazio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // canvasGroupLoading.enabled = true;
            _loadingScreen.SetActive(true);
            StartCoroutine(LoadScene("Theatre"));
        }

        //Carica la scena del menu  all'avvio del gioco
        if (currentScene.ToString() == "Menu")
        {
            //_player.GetComponent<FirstPersonCharacterController>().enabled = false;
        }

        //Carica la scena del gioco durante la visualizzazione della schermata di caricamento
        if (currentScene.ToString() == "Theatre")
        {
            //_player.GetComponent<FirstPersonCharacterController>().enabled = true;
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        _loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            yield return null;
        }

        StartCoroutine(LoadingScreenFadeOut(2f));
    }

    IEnumerator LoadingScreenFadeOut(float duration)
    {
        float timePassed = 0f;
        float startAlpha = _canvasGroupLoading.alpha;

        while(timePassed < duration)
        {
            timePassed += Time.deltaTime;
            _canvasGroupLoading.alpha = Mathf.Lerp(startAlpha, 0, timePassed / duration);
            yield return null;
        }

        currentScene = SceneLoader.Scene.Theatre;
        _loadingScreen.SetActive(false);
        _canvasGroupLoading.alpha = 1f;
    }
}