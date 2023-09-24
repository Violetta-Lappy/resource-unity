using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        instance = this;

        //SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);

        Debug.Log("Start Game");
    }

    public void LoadGame()
    {
        Debug.Log("Loading");

        loadingScreen.gameObject.SetActive(true);

        SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU);
        SceneManager.LoadSceneAsync((int)SceneIndexes.NGUYEN, LoadSceneMode.Additive);
    }
}
