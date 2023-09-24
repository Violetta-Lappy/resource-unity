using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlockTrigger : MonoBehaviour
{
    public enum DoorPositionInRoom {top,bot,left,right}

    public DoorPositionInRoom doorPositionInRoom;

    public WaveSystem waveSystem;
    
    private bool collided;

    public MeshRenderer blockRenderer;
    public Collider blockCollider;

    private RoomBoundManager roomBoundManager;
    private EndRoomManager endRoomManager;

    private Transform root;
    private void Start()
    {
        //wtf are these?
        root = transform.parent.parent.parent.parent;
        
        waveSystem = root.GetComponentInChildren<WaveSystem>();
        if (waveSystem == null)
        {
            endRoomManager = root.GetComponentInChildren<EndRoomManager>();
        }
        
        roomBoundManager = root.GetComponentInChildren<RoomBoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collided && other.CompareTag("Player"))
        {
            collided = true;
        }
    }

    public void EnableBlock()
    {
        blockRenderer.enabled = true;
        blockCollider.enabled = true;
    }

    public void DisableBlock()
    {
        blockRenderer.enabled = false;
        blockCollider.enabled = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (collided && other.CompareTag("Player") && HasEnteredRoom(other.transform.position))
        {
            //Lock the door here
            //print("Valid entering room");

            //if (waveSystem == null && endRoomManager == null) return;
            
            if (waveSystem != null)
            {
                if (!waveSystem.outOfWaves)
                {
                    waveSystem.LockRoom();
                }
            }

            if (endRoomManager != null)
            {
                endRoomManager.SpawnBoss();
            }

            if(roomBoundManager != null)
            {
                roomBoundManager.UpdateCameraBound();
            }
            
            DeadZone.instance.SetCurrentRoom(other.transform.position);
        }
    }

    bool HasEnteredRoom(Vector3 onExitPosition)
    {
        switch (doorPositionInRoom)
        {
            case DoorPositionInRoom.top when onExitPosition.x > transform.position.x:
                return true;
            case DoorPositionInRoom.bot when onExitPosition.x < transform.position.x:
                return true;
            case DoorPositionInRoom.left when onExitPosition.z > transform.position.z:
                return true;
            case DoorPositionInRoom.right when onExitPosition.z < transform.position.z:
                return true;
        }

        return false;
    }
}
