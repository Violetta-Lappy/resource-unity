using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added library
using TMPro;

public class CustomUIText : MonoBehaviour
{
    public ENUM_UI_TEXT_TYPE textType = ENUM_UI_TEXT_TYPE.NONE;
    public TextMeshProUGUI sampleTMPRO;    

    public void Setup()
    {
        sampleTMPRO = this.GetComponent<TextMeshProUGUI>();        
    }

    public void SetText(string text)
    {
        sampleTMPRO.text = text;
    }    

    public void SetActive(bool status = true)
    {
        this.transform.gameObject.SetActive(status);
    }
}
