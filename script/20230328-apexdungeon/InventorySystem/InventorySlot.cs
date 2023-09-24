using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;



public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler,IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    public ItemType itemType;
    private ItemInventory _item;

    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;

    public event Action<InventorySlot> OnPointerEnterEvent;
    public event Action<InventorySlot> OnPointerExitEvent;



    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);


    public ItemInventory item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.color = disabledColor;
            }
            else
            {
                image.sprite = _item.icon;
                image.color = normalColor;
            }
        }
    }


    public virtual bool CanReceiveItem(ItemInventory item)
    {
        if (item == null)
        {
            return true;
        }
        else
        {
            if (item.itemType == itemType)
            {
                return true;
            }
        }

        return false;
    }

    protected virtual void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    /*

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

    }
    */

    private Vector2 originalPos;

    public void OnDrag(PointerEventData eventData)
    {
        //  image.transform.position = Input.mousePosition;

        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //  originalPos = image.transform.position;

        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // tooltip.HideTooltip();
        if (OnPointerExitEvent != null)
        {
            OnPointerExitEvent(this);
        }
    }
}
