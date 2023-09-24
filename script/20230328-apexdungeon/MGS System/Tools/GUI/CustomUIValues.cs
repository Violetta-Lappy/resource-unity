using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
//UnityEngine.UI;
//TMPro;

public class CustomUIValues : MonoBehaviour
{
    [Header("Values")]
    public int[] arrIntValue = new int[1];
    public float[] arrFloatValue = new float[1];
    public UnityEngine.UI.Image[] arrImage;
    public TMPro.TextMeshProUGUI[] arrTMProUGUI;    

    private void Start()
    {
        
    }

    //Single index setter
    public void Setup1stIndex(int intValueToSet = 0, float floatValueToSet = 0.0f, UnityEngine.Sprite sprite = null, string text = "")
    {
        arrIntValue[0] = intValueToSet;
        arrFloatValue[0] = floatValueToSet;
        arrImage[0].sprite = sprite;
        arrTMProUGUI[0].text = text;
    }

    //Custom index maker
    public void SetupCustomIndex(int[] _arrIntValue, float[] _arrFloatValue, UnityEngine.Sprite[] _arrSprite = null, string[] _arrText = null)
    {
        //Set int array
        arrIntValue = _arrIntValue;

        //Set float array
        arrFloatValue = _arrFloatValue;

        //Set every image sprite
        int tempCounter = 0;
        foreach(UnityEngine.UI.Image image in arrImage)
        {
            //Skip this item if cannot found
            if(image == null) continue;

            tempCounter++;
            image.sprite = _arrSprite[tempCounter];
        }

        //Set every text
        int tempCounter02 = 0;
        foreach(TMPro.TextMeshProUGUI tmproUGUI in arrTMProUGUI)
        {
            //Skip this item if cannot found
            if(tmproUGUI == null) continue;

            tempCounter02++;
            tmproUGUI.text = _arrText[tempCounter02];
        }
    }
    
    #region SINGLE INDEX FUNCTIONS

    public int Get_IntValue1stIndex()
    {
        return arrIntValue[0];
    }

    public float Get_FloatValue1stIndex()
    {
        return arrFloatValue[0];
    }
    #endregion --SINGLE ITEM FUNCTIONS--

    #region CUSTOM INDEX FUNCTIONS

    public void Set_IntValueCustomIndex(int arrayID = 0, int valueToSet = 0)
    {
        arrIntValue[arrayID] = valueToSet;
    }

    public int Get_IntValueCustomIndex(int arrayID = 0)
    {
        return arrIntValue[arrayID];
    }
    
    public void Set_ValueCustomIndex(int arrayID = 0, float valueToSet = 0.0f)
    {
        arrFloatValue[arrayID] = valueToSet;
    }

    public float Get_ValueCustomIndex(int arrayID = 0)
    {
        return arrFloatValue[arrayID];
    }

    public void Set_SpriteCustomIndex(int arrayID = 0, UnityEngine.Sprite imageToSet = null)
    {
        arrImage[arrayID].sprite = imageToSet;
    }

    public void Set_TextCustomIndex(int arrayID = 0, string text = "")
    {
        arrTMProUGUI[arrayID].text = text;
    }
    #endregion --CUSTOM INDEX FUNCTIONS--

}
