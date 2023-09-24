using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    public static MinimapCameraController instance;
    
    public NewDungeonGeneration levelGenerator;

    public GameObject playerIconPrefab;
    private GameObject playerIcon;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        playerIcon = Instantiate(playerIconPrefab, transform.position, playerIconPrefab.transform.rotation);
    }

    public void SetMinimapCenter(Vector2Int positionInGrid)
    {
        Vector3 cameraPosition = new Vector3(levelGenerator.GetWorldPosition(positionInGrid).x, 200,
            levelGenerator.GetWorldPosition(positionInGrid).z);
        
        transform.position = cameraPosition;
        playerIcon.transform.position = new Vector3(cameraPosition.x, cameraPosition.y - 100f, cameraPosition.z) ;
    }
}
