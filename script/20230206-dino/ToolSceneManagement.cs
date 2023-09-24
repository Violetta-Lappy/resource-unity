using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ToolSceneManagement {        
    public static void LoadSceneCurrent() { UnityEngine.SceneManagement.SceneManager.LoadScene(GetCurrentSceneBuildID()); }
    public static void LoadSceneSpecific(int index) { UnityEngine.SceneManagement.SceneManager.LoadScene(index); }
    public static IEnumerator LoadSceneAsync(int index) {        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);        
        while (!asyncLoad.isDone) { yield return null; } // Wait until the asynchronous scene fully loads        
    }    
    public static int GetCurrentSceneBuildID() { return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; }    
}
