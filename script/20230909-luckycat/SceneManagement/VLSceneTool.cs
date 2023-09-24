using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VLGameProject.VLGui;

namespace VLGameProject.VLSceneManagement {
    public enum ENUM_SCENE {
        K_NONE = 0,
        K_SPLASH_SCREEN,
        K_LOADING_SCREEN,
        K_MAIN_MENU,
        K_GAMEPLAY,
        K_RESULT
    }

    public class VLSceneTool : Singleton<VLSceneTool> {

        public static ENUM_SCENE Get_Type_CurrentScene() { return Get_Scene_Type(Get_CurrentScene_BuildId()); }

        private static Dictionary<ENUM_SCENE, int> dict_sceneID = new Dictionary<ENUM_SCENE, int>() {
        {ENUM_SCENE.K_SPLASH_SCREEN, 0},
        {ENUM_SCENE.K_LOADING_SCREEN, 1},
        {ENUM_SCENE.K_MAIN_MENU, 2},
        {ENUM_SCENE.K_GAMEPLAY, 3},
        {ENUM_SCENE.K_RESULT, 4}
    };

        private static Dictionary<int, ENUM_SCENE> dict_sceneType = new Dictionary<int, ENUM_SCENE>() {
        {0, ENUM_SCENE.K_SPLASH_SCREEN},
        {1, ENUM_SCENE.K_LOADING_SCREEN},
        {2, ENUM_SCENE.K_MAIN_MENU},
        {3, ENUM_SCENE.K_GAMEPLAY},
        {4, ENUM_SCENE.K_RESULT}
    };

        private static int Get_SceneId(ENUM_SCENE _type) { return dict_sceneID[_type]; }
        private static ENUM_SCENE Get_Scene_Type(int _value) { return dict_sceneType[_value]; }

        public static int Get_CurrentScene_BuildId() { return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; }
        public static void Load_CurrentScene_AutoBuildIndex() => UnityEngine.SceneManagement.SceneManager.LoadScene(Get_CurrentScene_BuildId());
        public static void Load_Scene_Specific(ENUM_SCENE _type) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Get_SceneId(_type));
            //GameMode Setup
        }

        public void Load_Async_Scene_Specific(ENUM_SCENE _type) {
            StartCoroutine(Routine_Async_Load_Scene(Get_SceneId(_type)));
            //GameMode Setup
        }
        private static IEnumerator Routine_Async_Load_Scene(int _index) {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_index);
            while (!asyncLoad.isDone) {
                yield return null;
            } // Wait until the asynchronous scene fully loads                   
        }

        //If necessary
        public void Async_LoadScene_Specific(int _index) => StartCoroutine(Routine_Async_Load_Scene(_index));
        public static void LoadSceneSpecific(int _index) => UnityEngine.SceneManagement.SceneManager.LoadScene(_index);
        public static void LoadSceneAddictive(ENUM_SCENE _type) => UnityEngine.SceneManagement.SceneManager.LoadScene((int)_type);                
    }
}
