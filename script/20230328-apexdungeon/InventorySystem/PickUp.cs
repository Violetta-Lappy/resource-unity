using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public ItemInventory item;

    private void Awake()
    {
        gameObject.name = item.itemName;
    }

    /*
    private void OnValidate()
    {
        gameObject.name = item.itemName;
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (item.itemType)
            {
                case ItemType.consumable:
                    if (MasterGameSystem.Instance.consumableInventory.AddItem(item))
                    {
                        Destroy(gameObject);
                    }
                    break;
                case ItemType.modify:
                    if (MasterGameSystem.Instance.attachmentInventory.AddItem(item))
                    {
                        Destroy(gameObject);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
