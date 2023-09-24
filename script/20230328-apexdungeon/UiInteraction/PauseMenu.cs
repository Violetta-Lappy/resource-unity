using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject homeConfirmationPanel;
    public GameObject restartConfirmationPanel;
    public GameObject losePanel;
    public GameObject winPanel;


    public void PauseGame()
    {
        PlaySound();

        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
        PlaySound();

        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            PauseGame();
        }
        */

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Lose();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Win();
        }
        */
    }

    public void HomeMenu()
    {
        PlaySound();

        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void HomeConfirmation()
    {
        PlaySound();

        homeConfirmationPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void CloseHomeConfimation()
    {
        PlaySound();

        homeConfirmationPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void RestartGame()
    {
        PlaySound();

        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void CloseRestartConfirmation()
    {
        PlaySound();

        pauseMenuPanel.SetActive(true);
        restartConfirmationPanel.SetActive(false);
    }

    public void RestartConfirmation()
    {
        PlaySound();

        pauseMenuPanel.SetActive(false);
        restartConfirmationPanel.SetActive(true);
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlaySFX_UI(0);
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

}
