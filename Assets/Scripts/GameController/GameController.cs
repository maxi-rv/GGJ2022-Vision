using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Koffie.SimpleTasks;

public class GameController : MonoBehaviour
{
    //Singleton
    private static GameController instance;

    //COMPONENTS
    [SerializeField] private UIController uiController;
    [SerializeField] private AudioManager audioManager;
    public LevelController levelController;

    //VARIABLES
    [SerializeField] private GameObject playerPrefab;
    private PlayerController playerController;
    private GameObject playerInstance;
    private PlayerInputActions playerInputActions;
    private string currentSceneName;
    private bool onPlayingLevel;
    private int currentLevel;
    private bool playerSpawnPositionSetted;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //Preparing first message
        onPlayingLevel = false;
        currentLevel = -1;
        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Press Enter to Start, and go to intro scene
        if(playerInputActions.Player.Enter.IsPressed() && !onPlayingLevel && currentLevel!=0)
        {
            currentLevel = 0;
            uiController.playFade();
            audioManager.Play("Darks");

            STasks.Do(() => loadIntroScene(), after: 1.0f);
            STasks.Do(() => uiController.playFade(), after: 5.0f);
            STasks.Do(() => loadFirstLevel(), after: 6.0f);
        }
        else if(onPlayingLevel) //While playing a level
        {
            if(levelController!=null && !playerSpawnPositionSetted)
            {
                setPlayerPosition(levelController.getSpawnPoint());
                playerSpawnPositionSetted = true;
            }

            //Check if player finishes current level!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if(levelController!=null && levelController.playerReachedEnd)
            {
                levelController.playerReachedEnd = false;
                levelController = null;

                if(currentLevel==1)
                {
                    uiController.playFade();
                    STasks.Do(() => unloadScene(currentSceneName), after: 1.0f);
                    STasks.Do(() => loadSecondLevel(), after: 1.05f);
                }
                if(currentLevel==2)
                {
                    uiController.playFade();
                    STasks.Do(() => unloadScene(currentSceneName), after: 1.0f);
                    STasks.Do(() => loadThirdLevel(), after: 1.05f);
                }
                if(currentLevel==3)
                {
                    //QUE HACEMOS?!
                    uiController.playFade();
                    STasks.Do(() => Application.Quit(), after: 1.0f);
                }
            }
        }
    }

    private void loadIntroScene()
    {
        //Loads intro Scene
        currentSceneName = "Intro";
        loadScene(currentSceneName);
        
        //TO-DO: Play intro music!!!!!!!!!!

        //Updates HUD
        uiController.disableMessage();
        uiController.disableBackgroundMenu();
    }

    private void loadFirstLevel()
    {
        unloadScene(currentSceneName);
        currentLevel = 1;
        loadScene("Level"+currentLevel);
        onPlayingLevel = true;

        //Instantiates player and prepares to set its position
        instantiatePlayer();
        playerSpawnPositionSetted = false;

        //TO-DO: Play level 1 Music!!!!!!!
    }

    private void loadSecondLevel()
    {
        currentLevel = 2;
        loadScene("Level"+currentLevel);
        onPlayingLevel = true;

        //Prepares to set player position
        playerSpawnPositionSetted = false;

        //TO-DO: Play level 2 Music!!!!!!!
    }

    private void loadThirdLevel()
    {
        currentLevel = 3;
        loadScene("Level"+currentLevel);
        onPlayingLevel = true;

        //Prepares to set player position
        playerSpawnPositionSetted = false;

        //TO-DO: Play level 3 Music!!!!!!!
    }

    private void instantiatePlayer()
    {
        // Instantiating the Player
        Vector3 position = new Vector3(0f, 0f, 0f);
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        playerInstance = Instantiate(playerPrefab, position, rotation);
        playerInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);

        // Setting some variables
        playerController = playerInstance.GetComponent<PlayerController>();
    }

    private void destroyPlayer()
    {
        GameObject.Destroy(playerController.gameObject);
    }

    private void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        currentSceneName = scene;
    }

    private void reloadScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    private void unloadScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
        //TO-DO: STOP MUSIC!!!!!!!
    }

    //Places Player on SpawnPoint
    //PLAYER MUST ALREDY BE INSTANTIATED
    private void setPlayerPosition(Vector3 pos)
    {
        playerInstance.transform.position = pos;
    }
}
