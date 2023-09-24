using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

/*****************************************************************************************************************************
Author: DUONG DUC NGUYEN
Date Made: 09/11/2021
Object(s) holding this script: Resume Button, Main Menu Button, Start Button, Quit Button, Return Button, Options Buttion
Summary: 

*****************************************************************************************************************************/

public class Menus : MonoBehaviour
{
    public string levelName;
    public GameObject currentMenu;
    public GameObject newMenu;
    public Transform pauseMenu;
    public float duration;

    public GameObject exitConfirmationPanel;

    public void OpenLevel()
    {
        if (levelName != null) SceneManager.LoadScene(levelName);
    }

    public void OpenMenu()
    {
        if (currentMenu != null && newMenu != null)
        currentMenu.SetActive(false);
        newMenu.SetActive(true);
    }

    public void Resume()
    {
       // PlaySound();


        if (Time.timeScale == 0) 
        {
            /*Time.timeScale = 1;
            pauseMenu.DOScale(new Vector2(0, 0), duration)
            .OnComplete(()
            => {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            });*/

            Time.timeScale = 1;
            pauseMenu.DOScale(new Vector2(0, 0), duration).SetUpdate(true);

            //Set cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void QuitGame()
    {
      //  PlaySound();

        Application.Quit();
    }

    public void ExitConfirmation()
    {
        //PlaySound();
        Debug.Log("exit");
        exitConfirmationPanel.SetActive(true);
    }

    public void CloseExitConfirmation()
    {
       // PlaySound();
        exitConfirmationPanel.SetActive(false);
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlaySFX_UI(0);
    }
}
