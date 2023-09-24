using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    [HideInInspector] public Vector2Int positionInGrid;
    
    public bool doorTop, doorBot, doorLeft, doorRight;

    private void Start()
    {
        transform.Find("Minimap Icon").gameObject.SetActive(true);
    }
}

