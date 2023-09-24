using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] Inventory inventoryCon;

    [SerializeField] Inventory modPanel2;
    [SerializeField] Inventory modPanel1;


    public Tooltip tooltip;
    public Tooltip tooltipSecond;


    [SerializeField] ModPanel modPanel;
    [SerializeField] Image draggableItem;
    private InventorySlot draggedSlot;

    public List<ItemInventory> invenItems;

    public static InventoryManager Instance;


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        inventoryCon.OnBeginDragEvent += BeginDrag;
        modPanel.OnBeginDragEvent += BeginDrag;
        modPanel2.OnBeginDragEvent += BeginDrag;
        modPanel1.OnBeginDragEvent += BeginDrag;



        //End Drag
        inventory.OnEndDragEvent += EndDrag;
        inventoryCon.OnEndDragEvent += EndDrag;
        modPanel.OnEndDragEvent += EndDrag;
        modPanel2.OnEndDragEvent += EndDrag;
        modPanel1.OnEndDragEvent += EndDrag;



        //Drag
        inventory.OnDragEvent += Drag;
        inventoryCon.OnDragEvent += Drag;
        modPanel.OnDragEvent += Drag;
        modPanel2.OnDragEvent += Drag;
        modPanel1.OnDragEvent += Drag;


        //Drop
        inventory.OnDropEvent += Drop;
        inventoryCon.OnDropEvent += Drop;
        modPanel.OnDropEvent += Drop;
        modPanel2.OnDropEvent += Drop;
        modPanel1.OnDropEvent += Drop;

        //Pointer Enter
        inventory.OnPointerEnterEvent += PointerEnter;
        inventoryCon.OnPointerEnterEvent += PointerEnter;
        //modPanel.OnPointerEnterEvent += PointerEnter;
        modPanel2.OnPointerEnterEvent += PointerEnter;
        modPanel1.OnPointerEnterEvent += PointerEnter;

        //Pointer Enter
        inventory.OnPointerExitEvent += PointerExit;
        inventoryCon.OnPointerExitEvent += PointerExit;
        //modPanel.OnPointerEnterEvent += PointerExit;
        modPanel2.OnPointerExitEvent += PointerExit;
        modPanel1.OnPointerExitEvent += PointerExit;
    }

    public ItemInventory GetItem(string item)
    {
       foreach(ItemInventory inventoryItem in invenItems)
        {
            if(item == inventoryItem.itemName)
            {
                //Debug.Log("yo1");

                return inventoryItem;
            }
        }

       //Debug.Log("yo");
       
        return null;
    }




    private void BeginDrag(InventorySlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.enabled = true;
            draggableItem.sprite = itemSlot.item.icon;
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drag(InventorySlot itemSlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void EndDrag(InventorySlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drop(InventorySlot dropItemSlot)
    {
        if (draggedSlot == null) return;

        if (dropItemSlot.CanReceiveItem(draggedSlot.item) && draggedSlot.CanReceiveItem(dropItemSlot.item))
        {
            if (dropItemSlot is ModifySlot dropModSlot)
            {
                //Debug.Log("Drop to attachment slot");
                if (dropItemSlot.item is WeaponStatModifier pp)
                {
                    dropModSlot.gun.RemoveMod(pp);
                }
                
                if (dropItemSlot.item is ElementalModifier cc)
                {
                    dropModSlot.gun.RemoveStatus();
                }
                
                if (draggedSlot.item is WeaponStatModifier statItem)
                {
                    //Debug.Log("?");
                    dropModSlot.gun.AddMod(statItem);
                }

                if (draggedSlot.item is ElementalModifier elementalModifier)
                {
                    dropModSlot.gun.ChangeStatus(elementalModifier);
                }
            }

            if(draggedSlot is ModifySlot dragModSlot)
            {
                //Debug.Log("Drop from attachment slot");
                if (draggedSlot.item is WeaponStatModifier statItem)
                {
                    dragModSlot.gun.RemoveMod(statItem);
                }
                
                if (draggedSlot.item is ElementalModifier elementalModifier)
                {
                    dragModSlot.gun.RemoveStatus();
                }
                
                if (dropItemSlot.item is WeaponStatModifier pp)
                {
                    dragModSlot.gun.AddMod(pp);
                }
                
                if (dropItemSlot.item is ElementalModifier cc)
                {
                    dragModSlot.gun.ChangeStatus(cc);
                }
            }
            //Debug.Log("Swap");

            ItemInventory draggedItem = draggedSlot.item;
            draggedSlot.item = dropItemSlot.item;
            dropItemSlot.item = draggedItem;
            
        }
    }

    private void PointerEnter(InventorySlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            tooltip.ShowToolTip(itemSlot.item);

            if (draggedSlot != null)
            {
                if (draggedSlot.item != itemSlot.item)
                {
                    //Debug.Log("does not match");
                    tooltipSecond.ShowToolTip(draggedSlot.item);
                }
            }
        }
    }


    private void PointerExit(InventorySlot itemSlot)
    {
        tooltip.HideTooltip();
        tooltipSecond.HideTooltip();

    }

}
