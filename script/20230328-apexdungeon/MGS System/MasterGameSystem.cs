using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using System.Linq;
using UnityEngine.SceneManagement;
using Unity.AI.Navigation;

public class MasterGameSystem : Singleton_Persist<MasterGameSystem>
{
    public GameObject winPanel;

    [Header("Game Database")]
    //Always existed one Databases
    public DatabaseMain databaseMain;

    [Header("Other")]
    public GameObject player;
    public NavMeshSurface[] navMeshSurfaces;
    public Inventory attachmentInventory;
    public Inventory consumableInventory;

    [Header("MGS SYSTEM")]
    public bool isInitOnce = false;
    public float startGameTime = ProjectConstants.MGS_COUNTDOWN_GAME_START_TIME;
    public float inGameTime = 0.0f;
    public bool isGameStart = false;
    public bool isGameEnd = false;
    public ENUM_GAME_END_TYPE gameEndStatus = ENUM_GAME_END_TYPE.NONE_DRAW;

    public Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }

    public void BakeInRunTime()
    {
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }

        //Debug.Log("Successfully Update Nav Mesh");
    }

    #region SYSTEM RELATED
    //DO NOT TOUCH THIS, THIS IS FOR ENSURING GAME INIT STATE CORRECTLY
    //UNLESS YOU KNOW WHAT YOU DOING
    private void SysInitOnce()
    {
        if (isInitOnce == false)
        {
            //Reset any invoke releated  
            CancelInvoke();

            //DO NOT EDIT BELOW
            SaveDataMNG.InitSaveGame1stTime();

            GUIManager.Instance.InitGUISystem(null, true);

            AudioManager.Instance.InitMixer();

            isInitOnce = true;
        }
    }

    private void SysInitRepeated()
    {
        //Reset any invoke releated  
        CancelInvoke();

        //ADD ALL VARIABLE RELATED, AND SET IT ALL TO DEFAULT VALUE
        startGameTime = ProjectConstants.MGS_COUNTDOWN_GAME_START_TIME;

        inGameTime = 0.0f;

        isGameStart = false;
        isGameEnd = false;

        gameEndStatus = ENUM_GAME_END_TYPE.NONE_DRAW;
    }

    public void SysPause()
    {
        Time.timeScale = 0.0f;

        //Cursor Unlock        
        Cursor.lockState = CursorLockMode.None;
    }

    public void SysResume()
    {
        Time.timeScale = 1.0f;

        //Cursor Unlock        
        Cursor.lockState = CursorLockMode.None;
    }

    public void SysQuit()
    {
        Application.Quit();
    }

    #endregion SYSTEM RELATED    

    private void Start()
    {
        DebugSystem.CheckingFeaturesFromProjectConst();

        if (ProjectConstants.ENABLE_MGS_SYSTEM)
        {
            //DO NOT EDIT

            //System Init Once
            SysInitOnce();

            //System Init
            SysInitRepeated();

            //System must resume during the first frame
            SysResume();

            //DO NOT EDIT BELOW
            GameSystem_Start();
        }

        else if (ProjectConstants.ENABLE_MGS_SYSTEM == false)
        {
            TestingMode_Start();
        }
    }

    private void Update()
    {
        if (ProjectConstants.ENABLE_MGS_SYSTEM)
        {
            InputInterruptFromPlayer();

            GameSystem_Loop();
        }

        if (ProjectConstants.ENABLE_MGS_SYSTEM == false)
        {
            TestingMode_Update();
        }
    }

    private void LateUpdate()
    {
        CustomCursor.Instance.UpdateCursor();
    }

    #region TESTING MODE FUNCTIONS
    public void TestingMode_Start()
    {


    }

    public void TestingMode_Update()
    {


    }
    #endregion TESTING MODE FUNCTIONS

    //** GAME MANAGER FLOW **
    //-- Start Game Function --

    public void GameSystem_Start()
    {
        //DO NOT EDIT
        GameSystem_StartEdit();

        //DO NOT EDIT
        isGameStart = true;
        isGameEnd = false;
    }

    private void GameSystem_StartEdit()
    {
        //ALLOW EDIT
        //Add all game function inside here based on specific scene

        GUIManager.Instance.OpenUIShopPage_ViaBuyKey(false);

        switch (Get_CurrentSceneBuildID())
        {
            case (int)ENUM_SCENE_NAME.SPLASH_SCREEN:
                break;

            case (int)ENUM_SCENE_NAME.MAIN_MENU:
                AudioManager.Instance.PlayMusic((ENUM_AUDIO_MUSIC_TYPE)Random.Range(0, 2));
                GUIManager.Instance.OpenUIPage(ENUM_UI_PAGES_ID.MAIN_MENU, ENUM_UI_REQUEST_PAGE_ID.NONE, false, false);

                SaveDataMNG.Save_GameCurrency(0);
                break;

            case (int)ENUM_SCENE_NAME.GAMEPLAY:
                AudioManager.Instance.PlayMusic((ENUM_AUDIO_MUSIC_TYPE)Random.Range(2, 7));
                GUIManager.Instance.OpenUIPage(ENUM_UI_PAGES_ID.GAMEPLAY_NORMAL);

                //Add start game function below here
                break;

            case (int)ENUM_SCENE_NAME.TUTORIAL:
                AudioManager.Instance.PlayMusic((ENUM_AUDIO_MUSIC_TYPE)Random.Range(2, 7));
                GUIManager.Instance.OpenUIPage(ENUM_UI_PAGES_ID.GAMEPLAY_NORMAL);
                break;

            default:
                break;
        }
    }

    //-- Game Loop Function --    
    private void GameSystem_Loop()
    {
        //CHecking if system pause
        if (Time.timeScale != 0)
        {
            //DO NOT EDIT THIS FUNCTION
            if (isGameStart)
            {
                if (isGameEnd)
                {
                    GameSystem_End();
                }

                if (!isGameEnd)
                {
                    //Loop game function here
                    GameSystem_LoopEdit();
                }
            }
        }
    }

    private void GameSystem_LoopEdit()
    {
        //ALLOW EDIT
        //Add all game function inside here

        //Add any losing code here, must announce game end here

        UpdateInGameTime();
    }

    //-- Game End Function --
    private void GameSystem_End()
    {
        //DO NOT EDIT THIS FUNCTION
        isGameStart = false;

        GameEnd();
    }

    private void GameEnd()
    {
        //ALLOW EDIT
        //Add all function here when game end             

        switch (gameEndStatus)
        {
            case ENUM_GAME_END_TYPE.NONE_DRAW:
                break;

            case ENUM_GAME_END_TYPE.WIN:
                GUIManager.Instance.OpenUIPage(ENUM_UI_PAGES_ID.GAME_OVER, ENUM_UI_REQUEST_PAGE_ID.GAME_OVER_WIN, true);
                break;

            case ENUM_GAME_END_TYPE.LOSE:
                GUIManager.Instance.OpenUIPage(ENUM_UI_PAGES_ID.GAME_OVER, ENUM_UI_REQUEST_PAGE_ID.GAME_OVER_LOSE, true);
                break;
        }

        SysPause();
    }

    //EXTERNAL for Other Scripts
    public void Annouce_GameEnd(ENUM_GAME_END_TYPE gameEndType)
    {
        gameEndStatus = gameEndType;

        //Breakout of GameSystem_Loop
        isGameEnd = true;
    }

    public void UpdateInGameTime()
    {
        inGameTime += Time.deltaTime;
    }

    public void InputInterruptFromPlayer()
    {
        //ALLOW EDIT

        #region Restart Current Level From Key        
        if (ProjectConstants.ENABLE_RESTART_VIA_KEY_PRESS)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Load_CurrentScene_AutoBuildIndex();
            }
        }
        #endregion

        if (Get_CurrentSceneBuildID() != (int)ENUM_SCENE_NAME.MAIN_MENU
            && Get_CurrentSceneBuildID() != (int)ENUM_SCENE_NAME.SPLASH_SCREEN)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GUIManager.Instance.OpenUIShopPage_ViaBuyKey(true);
            }
        }

        PauseGameSystem();
    }

    public void PauseGameSystem()
    {
        #region Pause Game From Key (P and Escape)
        if (Time.timeScale != 0)
        {
            if (!isGameEnd)
            {
                if (ProjectConstants.ENABLE_PAUSE_VIA_KEY_PRESS)
                {
                    if (Get_CurrentSceneBuildID() != (int)ENUM_SCENE_NAME.MAIN_MENU
                    && Get_CurrentSceneBuildID() != (int)ENUM_SCENE_NAME.SPLASH_SCREEN)
                    {
                        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
                        {
                            GUIManager.Instance.OpenUIPage_ViaPauseKey(true);

                            SysPause();
                        }
                    }
                }
            }
        }

        //if game has paused, then resume it
        else if (Time.timeScale == 0)
        {
            if (!isGameEnd)
            {
                if (ProjectConstants.ENABLE_PAUSE_VIA_KEY_PRESS)
                {
                    if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
                    {
                        GUIManager.Instance.OpenUIPage_ViaPauseKey(false);

                        SysResume();
                    }
                }
            }
        }
        #endregion
    }



    #region SCENE MANAGER FUNCTIONS
    public void Load_CurrentScene_AutoBuildIndex()
    {
        StartCoroutine(WaitAndLoadScene(Get_CurrentSceneBuildID()));
    }

    public void Load_SpecificScene(ENUM_SCENE_NAME sceneID)
    {
        StartCoroutine(WaitAndLoadScene(sceneID));
    }

    private IEnumerator WaitAndLoadScene(ENUM_SCENE_NAME sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // Load in the background        

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((int)sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //After done loading set up the game
        //Start the Script
        Start();
    }

    private IEnumerator WaitAndLoadScene(int id)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // Load in the background        

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //After done loading set up the game
        //Start the Script
        Start();
    }

    public int Get_CurrentSceneBuildID()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    #endregion __SCENE MANAGER FUNCTIONS__
}
