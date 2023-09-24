using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAssignInventory : MonoBehaviour
{
    public bool isModNotConsumable = true;
    
    void Start()
    {
        if (isModNotConsumable)
        {
            GUIManager.Instance.modInventory = this.GetComponent<Inventory>();
        }

        else
            GUIManager.Instance.conInventory = this.GetComponent<Inventory>();
    }    
}
