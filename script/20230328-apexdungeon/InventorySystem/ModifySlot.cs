using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifySlot : InventorySlot
{
    public BaseGun02 gun;

    protected override void Awake()
    {
        base.Awake();

        gameObject.name = itemType.ToString() + "Slot";
    }

    /*
    protected override void OnValidate()
    {
        base.OnValidate();

        gameObject.name = itemType.ToString() + "Slot";
    }
    */

    public override bool CanReceiveItem(ItemInventory item)
    {
        if(item == null)
        {
            return true;
        }

        ItemInventory modItem = item as ItemInventory;
        // return modItem!=null && modItem.type == type;

        return modItem != null && modItem.itemType == ItemType.modify;
    }
}
