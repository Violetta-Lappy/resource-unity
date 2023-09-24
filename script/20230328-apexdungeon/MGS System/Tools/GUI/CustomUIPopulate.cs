using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUIPopulate : MonoBehaviour
{
    public ENUM_UI_POPULATE_TYPE populateType;
    public GameObject uiPrefab;    

    public void Setup()
    {
        GUIManager.Instance.PopulateUIMaker(populateType, this, uiPrefab);
    }
}
