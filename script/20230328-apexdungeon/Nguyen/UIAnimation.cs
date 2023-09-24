using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*****************************************************************************************************************************
Author: DUONG DUC NGUYEN
Date Made: 12/11/2021
Object(s) holding this script: Resume Button, Main Menu Button, Start Button, Quit Button, Return Button, Options Buttion
Summary: 

*****************************************************************************************************************************/

public class UIAnimation : MonoBehaviour
{
    public Transform currentMenu;
    public Transform targetMenu;

    private Vector2 close;
    public Vector2 open;

    private Vector2 normalScale;
    public Vector2 hoverScale;

    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        //targetMenu.transform.DOScale(close, 0.5f);
        normalScale = this.transform.localScale;
        close = new Vector2(0, 0);
    }

    public void OptionsMenu()
    {
        if (close != null && open != null)
        {
            currentMenu.DOScale(close,duration);
            targetMenu.DOScale(open, duration);
        }
    }

    public void MouseEnter()
    {
        transform.DOScale(hoverScale, duration).SetUpdate(true);
    }

    public void MouseExit()
    {
        transform.DOScale(normalScale, duration).SetUpdate(true);
    }
}
