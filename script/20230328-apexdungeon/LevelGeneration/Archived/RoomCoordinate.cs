// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class RoomCoordinate
// {
//     public bool isRoom;
//     public Vector3 worldPosition;
//
//     public RoomData roomData;
//     
//     public List<DoorPosition> expectedNeighbourDoors = new List<DoorPosition>();
//     public List<DoorPosition> blockedNeighbourDoors = new List<DoorPosition>();
//     public RoomCoordinate(Vector3 _worldPosition)
//     {
//         worldPosition = _worldPosition;
//     }
//
//     public void GetExpectedDoors()
//     {
//         if (roomData.doorTop)
//         {
//             expectedNeighbourDoors.Add(DoorPosition.Bot);
//         }
//         else
//         {
//             blockedNeighbourDoors.Add(DoorPosition.Bot);
//         }
//         
//         if (roomData.doorBot)
//         {
//             expectedNeighbourDoors.Add(DoorPosition.Top);
//         }
//         else
//         {
//             blockedNeighbourDoors.Add(DoorPosition.Top);
//         }
//         
//         if (roomData.doorLeft)
//         {
//             expectedNeighbourDoors.Add(DoorPosition.Right);
//         }
//         else
//         {
//             blockedNeighbourDoors.Add(DoorPosition.Right);
//         }
//         
//         if (roomData.doorRight)
//         {
//             expectedNeighbourDoors.Add(DoorPosition.Left);
//         }
//         else
//         {
//             blockedNeighbourDoors.Add(DoorPosition.Left);
//         }
//     }
// }
//
// public enum DoorPosition {Top,Bot,Left,Right,None}
