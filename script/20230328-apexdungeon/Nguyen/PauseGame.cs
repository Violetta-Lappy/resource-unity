using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*****************************************************************************************************************************
Author: DUONG DUC NGUYEN
Date Made: 09/11/2021
Object(s) holding this script: _PauseGame
Summary: 

*****************************************************************************************************************************/

public class PauseGame : MonoBehaviour
{
    public Transform menu;
    public float duration;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }

    private void Pause()
    {
        if (Time.timeScale != 0) 
        {
            Time.timeScale = 0;
            menu.DOScale(new Vector2(1, 1), duration).SetUpdate(true);

            //Set cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else 
        {
            Time.timeScale = 1;
            menu.DOScale(new Vector2(0, 0), duration).SetUpdate(true);

            //Set cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
