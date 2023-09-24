using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 20/10/2021
Object(s) holding this script: HealthBar
Summary: 
Set value and color of Health bar
***************************/

public class HealthSystem : MonoBehaviour
{
    public Image fillImg;
    private PlayerExample playerScript;
    private Slider slider;
    private float fillValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerExample>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set value of sider
        fillValue = playerScript.currentHealth / playerScript.maxHealth;
        slider.value = fillValue;
        SetFillColor();
    }

    //Set color of fill image
    //Called in Update()
    void SetFillColor()
    {
        if (fillValue <= slider.maxValue / 1.5 && fillValue > slider.maxValue / 3)
        {
            fillImg.color = Color.yellow;
        }
        else if (fillValue <= slider.maxValue / 3)
        {
            fillImg.color = Color.red;
        }
        else
        {
            fillImg.color = Color.green;
        }
    }


}
