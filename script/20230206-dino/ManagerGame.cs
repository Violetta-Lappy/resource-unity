using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerGame : SingletonBlank<ManagerGame>
{
    public bool isPlayerStart;
    public bool isGameEnd;
    public bool isGamePaused;

    public float f_gameSpeedIncrement = 0.2f;
    public float f_gameSpeed { get; private set; }

    private float f_playerScore = 0;
    
    void Start()
    {
        f_gameSpeedIncrement = ProjectConstants.K_GAMESPEED_INCREMENT;

        EventNewGame();
    }
    
    void Update()
    {
        if (isGameEnd == false && isPlayerStart == true)
        {
            f_gameSpeed += f_gameSpeedIncrement * Time.deltaTime;
            f_playerScore += f_gameSpeed * Time.deltaTime;
            GUIManager.Instance.UpdateTextScore(Mathf.Round(f_playerScore));
        }
    }

    void EventNewGame()
    {
        f_gameSpeed = ProjectConstants.K_INITIALGAMESPEED;

        Time.timeScale = 0f;

        isPlayerStart = false;

        isGameEnd = false;
    }

    public void EventGameOver()
    {
        EventPause();
        isGameEnd = true;
        Debug.Log("Game Over! Total score: " + Mathf.FloorToInt(f_playerScore));

        ManagerAudio.Instance.PlayGameSFX("death");
        ManagerAudio.Instance.MusicFadeOut(ProjectConstants.K_MUSIC_FADE_OUT_TIME);
    }

    public void EventPlayerStart() 
    { 
        Time.timeScale = 1f; 

        isPlayerStart = true; 
        GUIManager.Instance.UpdateTextScore(0.0f);

        ManagerAudio.Instance.MusicFadeIn(ProjectConstants.K_MUSIC_FADE_IN_TIME, true);
        ManagerAudio.Instance.PlayMusic("test", true);
    }

    public void EventPause() { Time.timeScale = 0f; isGamePaused = true; Cursor.lockState = CursorLockMode.None; }

    public void EventUnpause() { Time.timeScale = 1f; isGamePaused = false; Cursor.lockState = CursorLockMode.None; }

    public void EventGameReset() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); EventUnpause(); }

}
