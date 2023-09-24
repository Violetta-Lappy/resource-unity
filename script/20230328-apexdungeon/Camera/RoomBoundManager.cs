using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoundManager : MonoBehaviour
{
    public BoxCollider roomBound;
    public float xOffset = 15;
    public float zOffset = 10;
    private RoomData roomData;
    private void Start()
    {
        if (roomBound == null)
        {
            roomBound = GetComponent<BoxCollider>();
        }
        
        roomData = transform.parent.GetComponent<RoomData>();
    }

    public void UpdateCameraBound()
    {
        CinemachineCameraController.instance.xMaxBound = transform.position.x + roomBound.size.x - xOffset;
        CinemachineCameraController.instance.xMinBound = transform.position.x - roomBound.size.x + xOffset;
        CinemachineCameraController.instance.zMaxBound = transform.position.z + roomBound.size.z - zOffset;
        CinemachineCameraController.instance.zMinBound = transform.position.z - roomBound.size.z + zOffset;


        MinimapCameraController.instance?.SetMinimapCenter(roomData.positionInGrid);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Player")) 
    //     {
    //         CinemachineCameraController.instance.xMaxBound = transform.position.x + roomBound.size.x - xOffset;
    //         CinemachineCameraController.instance.xMinBound = transform.position.x - roomBound.size.x + xOffset;
    //         CinemachineCameraController.instance.zMaxBound = transform.position.z + roomBound.size.z - zOffset;
    //         CinemachineCameraController.instance.zMinBound = transform.position.z - roomBound.size.z + zOffset;
    //
    //    
    //         MinimapCameraController.instance?.SetMinimapCenter(roomData.positionInGrid);
    //     }
    // }
    
    // private void OnDrawGizmos()
    // {
    //     if (roomBound != null)
    //     {
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawSphere( new Vector3(transform.position.x + roomBound.size.x, transform.position.y,transform.position.z), 10f);
    //         Gizmos.DrawSphere( new Vector3(transform.position.x - roomBound.size.x, transform.position.y,transform.position.z), 10f);
    //         Gizmos.DrawSphere( new Vector3(transform.position.x , transform.position.y,transform.position.z + roomBound.size.z), 10f);
    //         Gizmos.DrawSphere( new Vector3(transform.position.x, transform.position.y,transform.position.z  - roomBound.size.z), 10f);
    //     }
    // }
}
