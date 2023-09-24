using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : Singleton_Blank<LevelLoader>
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshPro progressText;
    public bool isDungeonDone;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncchronously(sceneIndex));
    }

    IEnumerator LoadAsyncchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        
        while (isDungeonDone == false)
        {
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                //Debug.Log(progress);
                //progressText.text = progress * 100f + "%";

                yield return null;
            }

            yield return null;
        }       
        
        loadingScreen.SetActive(false);
    }

    public void Announce_DungeonDone()
    {
        isDungeonDone = true;
    }
}
