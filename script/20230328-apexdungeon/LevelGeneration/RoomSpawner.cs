using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum RoomType
{
    Normal,
    Start,
    End,
    Boss,
    Treasure,
}

[System.Serializable]
public class Room
{
    public RoomType roomType;
    public RoomData[] roomPrefabs;
}

public class RoomSpawner : MonoBehaviour
{
    public Room[] rooms;
    [HideInInspector] public GameObject spawnedRoom;
    [HideInInspector] public List<DoorPosition> openDoorPositions;
    [HideInInspector] public List<DoorPosition> closedDoorPositions;
    public Vector2Int positionInGrid;
    public void SpawnRoom(RoomType roomType, Vector3 spawnPosition)
    {
        foreach (var r in rooms)
        {
            if (r.roomType == roomType)
            {
                List<RoomData> sortedRoomDatas = new List<RoomData>();
                
                sortedRoomDatas = SortRoomDatas(r);
                int whichRoomData = Random.Range(0, sortedRoomDatas.Count);
                
                //Debug.Log(sortedRoomDatas[whichRoomData].name);
                
                GameObject roomPrefab = sortedRoomDatas[whichRoomData].gameObject;
                sortedRoomDatas[whichRoomData].positionInGrid = positionInGrid;
                spawnedRoom = Instantiate(roomPrefab, spawnPosition, Quaternion.identity);
                spawnedRoom.transform.parent = transform.parent;
            }
        }
    }

    List<RoomData> SortRoomDatas(Room room)
    {
        List<RoomData> sortedRoomDatas = new List<RoomData>();

        if (openDoorPositions.Count == 1)
        {
            if (openDoorPositions.Contains(DoorPosition.Bot))
            {
                foreach (var data in room.roomPrefabs)
                {
                    if (data.doorBot)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            if (openDoorPositions.Contains(DoorPosition.Top))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            if (openDoorPositions.Contains(DoorPosition.Left))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorLeft)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            if (openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
        }
        else if (openDoorPositions.Count == 2)
        {
            if (openDoorPositions.Contains(DoorPosition.Top) &&
                openDoorPositions.Contains(DoorPosition.Bot))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop && data.doorBot)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Top) &&
                openDoorPositions.Contains(DoorPosition.Left))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop && data.doorLeft)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Top) &&
                openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop && data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Left) &&
                openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorLeft && data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Bot) &&
                openDoorPositions.Contains(DoorPosition.Left))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorBot && data.doorLeft)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Bot) &&
                openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorBot && data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
        }
        else if (openDoorPositions.Count == 3)
        {
            if (openDoorPositions.Contains(DoorPosition.Top) &&
                openDoorPositions.Contains(DoorPosition.Bot) && openDoorPositions.Contains(DoorPosition.Left))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop && data.doorBot && data.doorLeft)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Top) &&
                openDoorPositions.Contains(DoorPosition.Bot) && openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop && data.doorBot && data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Top) &&
                openDoorPositions.Contains(DoorPosition.Left) && openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in  room.roomPrefabs)
                {
                    if (data.doorTop && data.doorLeft && data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
            
            if (openDoorPositions.Contains(DoorPosition.Bot) &&
                openDoorPositions.Contains(DoorPosition.Left) && openDoorPositions.Contains(DoorPosition.Right))
            {
                foreach (var data in room.roomPrefabs)
                {
                    if (data.doorBot && data.doorLeft && data.doorRight)
                    {
                        sortedRoomDatas.Add(data);
                    }
                }
            }
        }
        else
        {
            foreach (var data in  room.roomPrefabs)
            {
                if (data.doorBot && data.doorLeft && data.doorRight && data.doorTop)
                {
                    sortedRoomDatas.Add(data);
                }
            }
        }

        if (closedDoorPositions.Count > 0)
        {
            foreach (var blockedDirection in closedDoorPositions)
            {
                if (blockedDirection == DoorPosition.Bot)
                {
                    foreach (var data in  room.roomPrefabs)
                    {
                        if (data.doorBot)
                        {
                            sortedRoomDatas.Remove(data);
                        }
                    }
                }
                else if (blockedDirection == DoorPosition.Top)
                {
                    foreach (var data in  room.roomPrefabs)
                    {
                        if (data.doorTop)
                        {
                            sortedRoomDatas.Remove(data);
                        }
                    }
                }
                else if (blockedDirection == DoorPosition.Left)
                {
                    foreach (var data in  room.roomPrefabs)
                    {
                        if (data.doorLeft)
                        {
                            sortedRoomDatas.Remove(data);
                        }
                    }
                }
                else if (blockedDirection == DoorPosition.Right)
                {
                    foreach (var data in room.roomPrefabs)
                    {
                        if (data.doorRight)
                        {
                            sortedRoomDatas.Remove(data);
                        }
                    }
                }
            }
        }
        
        return sortedRoomDatas;
    }
    //TO DO: Use level generator script to find neighbour to determind aroudn neighbour which type of room to choose from
}
