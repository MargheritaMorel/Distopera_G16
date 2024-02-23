using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneLoader.Scene Loading;
    public SceneLoader.Scene Menu;
    public SceneLoader.Scene Game;
    public SceneLoader.Scene End;
    public SceneLoader.Scene currentScene;

    public GameObject player;

    //public SoundManager soundManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    //This function is called when the object becomes enabled and active to load the scene
    private void Start()
    {
        SceneLoader.LoaderCallback();
    }

    private void Update()
    {
        if (currentScene.ToString() == "Loading")
        {
            SceneLoader.Load(Menu);
            //SoundManager.instance.PlayBackgroundMusic("Loading", 0.7f);
            //player.GetComponent<PlayerMovement>().enabled = false;
        }

        if (currentScene.ToString() == "Menu")
        {
            SceneLoader.Load(Game);
            //SoundManager.instance.PlayBackgroundMusic("Menu", 0.7f);
            //player.GetComponent<PlayerMovement>().enabled = false;
        }

        if (currentScene.ToString() == "Game")
        {
            SceneLoader.Load(End);
            //SoundManager.instance.PlayBackgroundMusic("Game", 0.7f);
            //player.GetComponent<PlayerMovement>().enabled = true;
        }

        if (currentScene.ToString() == "End")
        {
            SceneLoader.Load(Menu);
            //SoundManager.instance.PlayBackgroundMusic("End", 0.7f);
            //player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}

