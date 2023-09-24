using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    consumable,
    modify,
}

[CreateAssetMenu]
public class ItemInventory : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType itemType = ItemType.modify;
}
