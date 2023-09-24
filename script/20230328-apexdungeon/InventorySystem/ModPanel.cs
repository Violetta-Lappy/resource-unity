using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModPanel : MonoBehaviour
{
    [SerializeField] private Transform modSlotParent;
    [SerializeField] private ModifySlot[] modSlots;


    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < modSlots.Length; i++)
        {
            modSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            modSlots[i].OnEndDragEvent += OnEndDragEvent;
            modSlots[i].OnDragEvent += OnDragEvent;
            modSlots[i].OnDropEvent += OnDropEvent;
        }


        modSlots = modSlotParent.GetComponentsInChildren<ModifySlot>();
    }

    /*
    private void OnValidate()
    {
        modSlots = modSlotParent.GetComponentsInChildren<ModifySlot>();
    }
    */

    public bool AddItem(ItemInventory item,out ItemInventory previousItem)
    {
        for(int i = 0; i < modSlots.Length; i++)
        {
            // if(modSlots[i].type == item.type)
            if (modSlots[i].itemType == item.itemType)
            {
                previousItem = (ItemInventory) modSlots[i].item;
                modSlots[i].item = item;
                return true;
            }
        }
        previousItem = null;  
        return false;
    }

    public bool RemoveItem(ItemInventory item)
    {
        for (int i = 0; i < modSlots.Length; i++)
        {
            if (modSlots[i].item == item)
            {
                modSlots[i].item = null;
                return true;
            }
        }

        return false;
    }
}
