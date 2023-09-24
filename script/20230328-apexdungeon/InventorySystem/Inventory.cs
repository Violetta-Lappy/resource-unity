using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class Inventory : MonoBehaviour
{
    public BaseGun02 gun;
    [SerializeField] private List<ItemInventory> items;
    [SerializeField] private Transform itemParent;
    [SerializeField] private InventorySlot[] itemSlots;

    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    
    public event Action<InventorySlot> OnPointerExitEvent;
    public event Action<InventorySlot> OnPointerEnterEvent;

    private void Start()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;

            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;

            if(itemSlots[i] is ModifySlot modSlot)
            {
                modSlot.gun = gun;
            }
        }

        RefreshUI();
    }

    private void Awake()
    {
        if (itemParent != null)
        {
            itemSlots = itemParent.GetComponentsInChildren<InventorySlot>();
        }

    }


    private void RefreshUI()
    {
        int i = 0;

        for(;i<items.Count && i < itemSlots.Length; i++){
            itemSlots[i].item = items[i];
        }

        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].item = null;
        }
    }

    public bool AddItem(ItemInventory item)
    {
        for (int i =0;i< itemSlots.Length;i++)
        {
            if(itemSlots[i].item == null)
            {
                itemSlots[i].item = item;
                items.Add(item);
                RefreshUI();

                return true;
            }
        }
        return false;
    }

    private void CheckUIIcon()
    {
        for(int i =0; i < items.Count; i++)
        {
            if(itemSlots[i].GetComponent<Image>().sprite == null)
            {
                Debug.Log(itemSlots[i] + "does not have icon " + items[i]);
            }
        }
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool RemoveItem(ItemInventory item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
            {
                itemSlots[i].item = null;
                return true;
            }
        }
        return false;
    }

}
