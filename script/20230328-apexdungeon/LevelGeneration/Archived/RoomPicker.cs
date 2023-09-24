using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicker : MonoBehaviour
{
    public GameObject startRoom;
    [HideInInspector] public GameObject spawnedRoom;

    public List<RoomData> normalRoomDatas;

    // public List<RoomData> noTopDatas = new List<RoomData>();
    // public List<RoomData> noBotDatas = new List<RoomData>(); 
    // public List<RoomData> noLeftDatas = new List<RoomData>();
    // public List<RoomData> noRightDatas = new List<RoomData>();

    // private void Start()
    // {
    //     foreach (var roomData in normalRoomDatas)
    //     {
    //         if (!roomData.doorTop)
    //         {
    //             noTopDatas.Add(roomData);
    //         }
    //         
    //         if (!roomData.doorBot)
    //         {
    //             noBotDatas.Add(roomData);
    //         }
    //         
    //         if (!roomData.doorLeft)
    //         {
    //             noLeftDatas.Add(roomData);
    //         }
    //         
    //         if (!roomData.doorRight)
    //         {
    //             noRightDatas.Add(roomData);
    //         }
    //     }
    // }

    public void SpawnRoom(GameObject roomPrefab, Vector3 worldPosition)
    {
        //Clear the holder first
        spawnedRoom = null;
        
        //Spawn the chosen room and attached it to the holder
        spawnedRoom = Instantiate(roomPrefab, worldPosition, Quaternion.identity);
    }

    public void SpawnRoom(List<RoomData> datas, Vector3 worldPosition)
    {
        //Clear the holder first
        spawnedRoom = null;
        
        //Spawn the chosen room and attached it to the holder
        spawnedRoom = Instantiate(datas[Random.Range(0, datas.Count)].gameObject, worldPosition, Quaternion.identity);
    }
}

