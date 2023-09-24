// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
//
// public class LevelGenerator : MonoBehaviour
// {
//     public int desiredNumberOfRoom;
//     
//     [Header("Grid generation")] 
//     public float roomWidth;
//     public float roomLength;
//     public int gridSizeX;
//     public int gridSizeY;
//     private Vector2Int startPoint;
//     
//     public RoomCoordinate[,] grid;
//     public List<Vector2Int> availablePoints;
//
//     public RoomPicker roomPicker;
//     
//     private int currentRoomCount;
//     
//     List<Vector2Int> firstFourRooms = new List<Vector2Int>();
//     
//     // Start is called before the first frame update
//     void Start()
//     {
//         SetUpGrid();
//         CreateRoom();
//     }
//     
//     void SetUpGrid()
//     {
//         //Set the value for the start point coordinate
//         startPoint = new Vector2Int((int) gridSizeX / 2, (int) gridSizeY / 2);
//         
//         //Initialize the size grid 2d array
//         grid = new RoomCoordinate[gridSizeX, gridSizeY];
//         
//         //The origin of the array
//         Vector3 originPoint = transform.position - Vector3.right * ((int)(roomWidth * gridSizeX)) / 2 - Vector3.forward * ((int)(roomLength * gridSizeY)) / 2;
//         
//         //Create the array by initialize new RoomCoordinate with object have a reference of where should it be in the world 
//         for (int x = 0; x < gridSizeX; x++)
//         {
//             for (int y = 0; y < gridSizeY; y++)
//             {
//                 Vector3 worldPosition = originPoint + Vector3.right * (x * roomWidth + roomWidth / 2) + Vector3.forward * (y * roomLength + roomLength/2);
//                 grid[x, y] = new RoomCoordinate(worldPosition);
//             }
//         }
//     }
//
//     void CreateRoom()
//     {
//         if (roomPicker == null) return;
//
//         //Initialise the start room at the middle of the grid
//         roomPicker.SpawnRoom(roomPicker.startRoom, grid[startPoint.x, startPoint.y].worldPosition);
//         grid[startPoint.x, startPoint.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//         grid[startPoint.x, startPoint.y].isRoom = true;
//         grid[startPoint.x, startPoint.y].GetExpectedDoors();
//         currentRoomCount++;
//
//
//         //Initiate four satellites 
//         foreach (var doorPosition in grid[startPoint.x, startPoint.y].expectedNeighbourDoors)
//         {
//             if (doorPosition == DoorPosition.Bot)
//             {
//                 List<RoomData> tempList = new List<RoomData>();
//                 //Must find a list of data containing every possible room that has top door
//                 foreach (var data in roomPicker.normalRoomDatas)
//                 {
//                     if (data.doorTop)
//                     {
//                         tempList.Add(data);
//                     }
//                 }
//
//                 Vector2Int tempPoint = new Vector2Int(startPoint.x + 1, startPoint.y);
//                 firstFourRooms.Add(tempPoint);
//                 roomPicker.SpawnRoom(tempList, grid[tempPoint.x, tempPoint.y].worldPosition);
//                 grid[tempPoint.x, tempPoint.y].isRoom = true;
//                 grid[tempPoint.x, tempPoint.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//                 grid[tempPoint.x, tempPoint.y].GetExpectedDoors();
//                 currentRoomCount++;
//             }
//
//             if (doorPosition == DoorPosition.Top)
//             {
//                 List<RoomData> tempList = new List<RoomData>();
//
//                 //Must find a list of data containing every possible room that has top door
//                 foreach (var data in roomPicker.normalRoomDatas)
//                 {
//                     if (data.doorBot)
//                     {
//                         tempList.Add(data);
//                     }
//                 }
//
//                 Vector2Int tempPoint = new Vector2Int(startPoint.x - 1, startPoint.y);
//                 firstFourRooms.Add(tempPoint);
//                 roomPicker.SpawnRoom(tempList, grid[tempPoint.x, tempPoint.y].worldPosition);
//                 grid[tempPoint.x, tempPoint.y].isRoom = true;
//                 grid[tempPoint.x, tempPoint.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//                 grid[tempPoint.x, tempPoint.y].GetExpectedDoors();
//                 currentRoomCount++;
//             }
//
//             if (doorPosition == DoorPosition.Left)
//             {
//                 List<RoomData> tempList = new List<RoomData>();
//
//                 //Must find a list of data containing every possible room that has top door
//                 foreach (var data in roomPicker.normalRoomDatas)
//                 {
//                     if (data.doorRight)
//                     {
//                         tempList.Add(data);
//                     }
//                 }
//
//                 Vector2Int tempPoint = new Vector2Int(startPoint.x, startPoint.y - 1);
//                 firstFourRooms.Add(tempPoint);
//                 roomPicker.SpawnRoom(tempList, grid[tempPoint.x, tempPoint.y].worldPosition);
//                 grid[tempPoint.x, tempPoint.y].isRoom = true;
//                 grid[tempPoint.x, tempPoint.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//                 grid[tempPoint.x, tempPoint.y].GetExpectedDoors();
//                 currentRoomCount++;
//             }
//
//             if (doorPosition == DoorPosition.Right)
//             {
//                 List<RoomData> tempList = new List<RoomData>();
//
//                 //Must find a list of data containing every possible room that has top door
//                 foreach (var data in roomPicker.normalRoomDatas)
//                 {
//                     if (data.doorLeft)
//                     {
//                         tempList.Add(data);
//                     }
//                 }
//
//                 Vector2Int tempPoint = new Vector2Int(startPoint.x, startPoint.y + 1);
//                 firstFourRooms.Add(tempPoint);
//                 roomPicker.SpawnRoom(tempList, grid[tempPoint.x, tempPoint.y].worldPosition);
//                 grid[tempPoint.x, tempPoint.y].isRoom = true;
//                 grid[tempPoint.x, tempPoint.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//                 grid[tempPoint.x, tempPoint.y].GetExpectedDoors();
//                 currentRoomCount++;
//
//                 //     List<Vector2Int> validNeighbours = GetNeighbours(grid[tempPoint.x, tempPoint.y].expectedNeighbourDoors,
//                 //         new Vector2Int(tempPoint.x, tempPoint.y));
//                 //
//                 //     Vector2Int rand = validNeighbours[UnityEngine.Random.Range(0, validNeighbours.Count)];
//                 //     
//                 //     print(rand);
//                 //
//                 //     List<DoorPosition> blockedDoorPositions = GetBlockedDirection(rand);
//                 //     List<DoorPosition> availableDoorPositions = GetExpectedDirection(rand);
//                 //     
//                 //     // print("Blocked : " + blockedDoorPositions.Count);
//                 //     
//                 //     List<RoomData> temp = new List<RoomData>();
//                 //     if (availableDoorPositions.Count == 1)
//                 //     {
//                 //         if (availableDoorPositions[0] == DoorPosition.Bot)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorBot)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         if (availableDoorPositions[0] == DoorPosition.Top)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         if (availableDoorPositions[0] == DoorPosition.Left)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorLeft)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         if (availableDoorPositions[0] == DoorPosition.Right)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //     }
//                 //     else if (availableDoorPositions.Count == 2)
//                 //     {
//                 //         if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Bot))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop && data.doorBot)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Left))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop && data.doorLeft)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Right))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop && data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Left) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Right))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorLeft && data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Bot) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Left))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorBot && data.doorLeft)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Bot) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Right))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorBot && data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //     }
//                 //     else if (availableDoorPositions.Count == 3)
//                 //     {
//                 //         if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Bot) && availableDoorPositions.Contains(DoorPosition.Left))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop && data.doorBot && data.doorLeft)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Bot) && availableDoorPositions.Contains(DoorPosition.Right))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop && data.doorBot && data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Left) && availableDoorPositions.Contains(DoorPosition.Right))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop && data.doorLeft && data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         
//                 //         if (availableDoorPositions.Contains(DoorPosition.Bot) &&
//                 //             availableDoorPositions.Contains(DoorPosition.Left) && availableDoorPositions.Contains(DoorPosition.Right))
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorBot && data.doorLeft && data.doorRight)
//                 //                 {
//                 //                     temp.Add(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //     }
//                 //     else
//                 //     {
//                 //         foreach (var data in roomPicker.normalRoomDatas)
//                 //         {
//                 //             if (data.doorBot && data.doorLeft && data.doorRight && data.doorTop)
//                 //             {
//                 //                 temp.Add(data);
//                 //             }
//                 //         }
//                 //     }
//                 //
//                 //     // foreach (var expectedDirection in availableDoorPositions)
//                 //     // {
//                 //     //     
//                 //     // }
//                 //     
//                 //     foreach (var blockedDirection in blockedDoorPositions)
//                 //     {
//                 //         if (blockedDirection == DoorPosition.Bot)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorBot)
//                 //                 {
//                 //                     temp.Remove(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         else if (blockedDirection == DoorPosition.Top)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorTop)
//                 //                 {
//                 //                     temp.Remove(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         else if (blockedDirection == DoorPosition.Left)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorLeft)
//                 //                 {
//                 //                     temp.Remove(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //         else if (blockedDirection == DoorPosition.Right)
//                 //         {
//                 //             foreach (var data in roomPicker.normalRoomDatas)
//                 //             {
//                 //                 if (data.doorRight)
//                 //                 {
//                 //                     temp.Remove(data);
//                 //                 }
//                 //             }
//                 //         }
//                 //     }
//                 //     
//                 //     roomPicker.SpawnRoom(temp, grid[rand.x, rand.y].worldPosition);
//                 //     grid[rand.x, rand.y].isRoom = true;
//                 //     grid[rand.x, rand.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//                 //     grid[rand.x, rand.y].GetExpectedDoors();
//                 //     currentRoomCount++;
//             }
//         }
//         
//         // CreateNeighbourFromFirstRooms(firstFourRooms);
//     }
//
//     void Foo()
//     {
//         //Get a random from the first four rooms
//         Vector2Int rand = firstFourRooms[UnityEngine.Random.Range(0, firstFourRooms.Count)];
//         
//         
//     }
//     //
//     // IEnumerator IntializeIsRoomCoordinateRoutine()
//     // {
//     //     
//     // }
//     //
//     
//     void CreateNeighbourFromFirstRooms(List<Vector2Int> listOfPoints)
//     {
//         List<Vector2Int> thisListOfRooms = new List<Vector2Int>();
//
//         
//         foreach (var point in listOfPoints)
//             {
//                 if(FindEmptyNeighbour(point).Count <=0) continue;
//                 List<Vector2Int> validNeighbours = GetNeighbours(grid[point.x, point.y].expectedNeighbourDoors, new Vector2Int(point.x, point.y));
//                 print("validNeighbours " + validNeighbours.Count);
//                 
//                 if(validNeighbours.Count == 0) continue;
//
//                 Vector2Int rand = validNeighbours[UnityEngine.Random.Range(0, validNeighbours.Count)];
//
//                 foreach (var neighbour in validNeighbours)
//                 {
//                     //The chosen random coordinate is the same as this iteration neighbour
//                     if (rand.x == neighbour.x && rand.y == neighbour.y) continue;
//                     
//                     availablePoints.Add(neighbour);
//                 }
//                 
//                 // print(rand);
//                 
//                 List<DoorPosition> blockedDoorPositions = GetBlockedDirection(rand);
//                 List<DoorPosition> availableDoorPositions = GetExpectedDirection(rand);
//                 
//                 // print("blocked " + blockedDoorPositions.Count);
//                 // print("available " + availableDoorPositions.Count);
//
//                 // print("Blocked : " + blockedDoorPositions.Count);
//                 
//                 List<RoomData> temp = new List<RoomData>();
//
//                 if (availableDoorPositions.Count == 1)
//                 {
//                     if (availableDoorPositions.Contains(DoorPosition.Bot))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorBot)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     if (availableDoorPositions.Contains(DoorPosition.Top))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     if (availableDoorPositions.Contains(DoorPosition.Left))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorLeft)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     if (availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                 }
//                 else if (availableDoorPositions.Count == 2)
//                 {
//                     if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                         availableDoorPositions.Contains(DoorPosition.Bot))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop && data.doorBot)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                         availableDoorPositions.Contains(DoorPosition.Left))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop && data.doorLeft)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                         availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop && data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Left) &&
//                         availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorLeft && data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Bot) &&
//                         availableDoorPositions.Contains(DoorPosition.Left))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorBot && data.doorLeft)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Bot) &&
//                         availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorBot && data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                 }
//                 else if (availableDoorPositions.Count == 3)
//                 {
//                     if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                         availableDoorPositions.Contains(DoorPosition.Bot) && availableDoorPositions.Contains(DoorPosition.Left))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop && data.doorBot && data.doorLeft)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                         availableDoorPositions.Contains(DoorPosition.Bot) && availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop && data.doorBot && data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Top) &&
//                         availableDoorPositions.Contains(DoorPosition.Left) && availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorTop && data.doorLeft && data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                     
//                     if (availableDoorPositions.Contains(DoorPosition.Bot) &&
//                         availableDoorPositions.Contains(DoorPosition.Left) && availableDoorPositions.Contains(DoorPosition.Right))
//                     {
//                         foreach (var data in roomPicker.normalRoomDatas)
//                         {
//                             if (data.doorBot && data.doorLeft && data.doorRight)
//                             {
//                                 temp.Add(data);
//                             }
//                         }
//                     }
//                 }
//                 else
//                 {
//                     foreach (var data in roomPicker.normalRoomDatas)
//                     {
//                         if (data.doorBot && data.doorLeft && data.doorRight && data.doorTop)
//                         {
//                             temp.Add(data);
//                         }
//                     }
//                 }
//
//                 if (blockedDoorPositions.Count > 0)
//                 {
//                     foreach (var blockedDirection in blockedDoorPositions)
//                     {
//                         if (blockedDirection == DoorPosition.Bot)
//                         {
//                             foreach (var data in roomPicker.normalRoomDatas)
//                             {
//                                 if (data.doorBot)
//                                 {
//                                     temp.Remove(data);
//                                 }
//                             }
//                         }
//                         else if (blockedDirection == DoorPosition.Top)
//                         {
//                             foreach (var data in roomPicker.normalRoomDatas)
//                             {
//                                 if (data.doorTop)
//                                 {
//                                     temp.Remove(data);
//                                 }
//                             }
//                         }
//                         else if (blockedDirection == DoorPosition.Left)
//                         {
//                             foreach (var data in roomPicker.normalRoomDatas)
//                             {
//                                 if (data.doorLeft)
//                                 {
//                                     temp.Remove(data);
//                                 }
//                             }
//                         }
//                         else if (blockedDirection == DoorPosition.Right)
//                         {
//                             foreach (var data in roomPicker.normalRoomDatas)
//                             {
//                                 if (data.doorRight)
//                                 {
//                                     temp.Remove(data);
//                                 }
//                             }
//                         }
//                     }
//                 }
//                
//
//                 // print("Temp " + temp.Count);
//                 
//                 roomPicker.SpawnRoom(temp, grid[rand.x, rand.y].worldPosition);
//                 grid[rand.x, rand.y].isRoom = true;
//                 grid[rand.x, rand.y].roomData = roomPicker.spawnedRoom.GetComponent<RoomData>();
//                 grid[rand.x, rand.y].GetExpectedDoors();
//                 currentRoomCount++;
//                 thisListOfRooms.Add(rand);
//             }
//
//         //Recursion until can have roughly the desired number of rooms
//         while (currentRoomCount + availablePoints.Count < desiredNumberOfRoom)
//         {
//             if(thisListOfRooms.Count == 0) continue;
//             
//             CreateNeighbourFromFirstRooms(thisListOfRooms);
//         }
//     }
//
//     List<DoorPosition> GetExpectedDirection(Vector2Int pointToCheck)
//     {
//         List<DoorPosition> expectedDirection = new List<DoorPosition>();
//
//         if (grid[pointToCheck.x + 1, pointToCheck.y].isRoom)
//         {
//             // print(grid[pointToCheck.x + 1, pointToCheck.y].roomData.gameObject.name);
//             if (grid[pointToCheck.x + 1, pointToCheck.y].expectedNeighbourDoors.Contains(DoorPosition.Bot))
//             {
//                 expectedDirection.Add(DoorPosition.Bot);
//             }
//         } 
//             
//         if (grid[pointToCheck.x - 1, pointToCheck.y].isRoom)
//         {
//             // print(grid[pointToCheck.x - 1, pointToCheck.y].roomData.gameObject.name);
//
//             if (grid[pointToCheck.x - 1, pointToCheck.y].expectedNeighbourDoors.Contains(DoorPosition.Top))
//             {
//                 expectedDirection.Add(DoorPosition.Top);
//             }
//         } 
//         
//         if (grid[pointToCheck.x , pointToCheck.y + 1].isRoom)
//         {
//             // print(grid[pointToCheck.x , pointToCheck.y + 1].roomData.gameObject.name);
//
//             if (grid[pointToCheck.x, pointToCheck.y + 1].expectedNeighbourDoors.Contains(DoorPosition.Right))
//             {
//                 expectedDirection.Add(DoorPosition.Right);
//             }
//         } 
//         
//         if (grid[pointToCheck.x , pointToCheck.y - 1].isRoom)
//         {
//             // print(grid[pointToCheck.x , pointToCheck.y - 1].roomData.gameObject.name);
//
//             if (grid[pointToCheck.x, pointToCheck.y - 1].expectedNeighbourDoors.Contains(DoorPosition.Left))
//             {
//                 expectedDirection.Add(DoorPosition.Left);
//             }
//         }
//
//         // foreach (var test in  expectedDirection)
//         // {
//         //     print($"Expected direction is {test}");
//         // }
//         //
//         return expectedDirection;
//     }
//     
//     List<DoorPosition> GetBlockedDirection(Vector2Int pointToCheck)
//     {
//         List<DoorPosition> blockedDirections = new List<DoorPosition>();
//
//         
//         if (grid[pointToCheck.x + 1, pointToCheck.y].isRoom)
//         {
//             // print(grid[pointToCheck.x + 1, pointToCheck.y].roomData.gameObject.name);
//             if (grid[pointToCheck.x + 1, pointToCheck.y].blockedNeighbourDoors.Contains(DoorPosition.Bot))
//             {
//                 blockedDirections.Add(DoorPosition.Bot);
//             }
//         } 
//             
//         if (grid[pointToCheck.x - 1, pointToCheck.y].isRoom)
//         {
//             // print(grid[pointToCheck.x - 1, pointToCheck.y].roomData.gameObject.name);
//
//             if (grid[pointToCheck.x - 1, pointToCheck.y].blockedNeighbourDoors.Contains(DoorPosition.Top))
//             {
//                 blockedDirections.Add(DoorPosition.Top);
//             }
//         } 
//         
//         if (grid[pointToCheck.x , pointToCheck.y + 1].isRoom)
//         {
//             // print(grid[pointToCheck.x , pointToCheck.y + 1].roomData.gameObject.name);
//
//             if (grid[pointToCheck.x, pointToCheck.y + 1].blockedNeighbourDoors.Contains(DoorPosition.Right))
//             {
//                 blockedDirections.Add(DoorPosition.Right);
//             }
//         } 
//         
//         if (grid[pointToCheck.x , pointToCheck.y - 1].isRoom)
//         {
//             // print(grid[pointToCheck.x , pointToCheck.y - 1].roomData.gameObject.name);
//
//             if (grid[pointToCheck.x, pointToCheck.y - 1].blockedNeighbourDoors.Contains(DoorPosition.Left))
//             {
//                 blockedDirections.Add(DoorPosition.Left);
//             }
//         } 
//         
//         // foreach (var test in  blockedDirections)
//         // {
//         //     print($"Blocked direction is {test}");
//         // }
//         
//         return blockedDirections;
//     }
//
//     List<Vector2Int> GetNeighbours(List<DoorPosition> expectedDirections, Vector2Int pointToCheck)
//     {
//         List<Vector2Int> neighbours = new List<Vector2Int>();
//
//         foreach (var direction in expectedDirections)
//         {
//             Vector2Int temp = new Vector2Int();
//             
//             if (direction == DoorPosition.Bot)
//             {
//                 temp = new Vector2Int(pointToCheck.x - 1, pointToCheck.y);
//                 if (!grid[temp.x, temp.y].isRoom)
//                 {
//                     neighbours.Add(temp);     
//                 }
//             }
//             else if (direction == DoorPosition.Top)
//             {
//                 temp = new Vector2Int(pointToCheck.x + 1, pointToCheck.y);
//                 if (!grid[temp.x, temp.y].isRoom)
//                 {
//                     neighbours.Add(temp);     
//                 }     
//             }
//             else if (direction == DoorPosition.Left)
//             {
//                 temp = new Vector2Int(pointToCheck.x, pointToCheck.y + 1);
//                 if (!grid[temp.x, temp.y].isRoom)
//                 {
//                     neighbours.Add(temp);     
//                 }      
//             }
//             else if (direction == DoorPosition.Right)
//             {
//                 temp = new Vector2Int(pointToCheck.x, pointToCheck.y - 1);
//                 if (!grid[temp.x, temp.y].isRoom)
//                 {
//                     neighbours.Add(temp);     
//                 }    
//             }
//         }
//         
//         // foreach (var n in neighbours)
//         // {
//         //     print($"Neighbour point in array is {n.x} , {n.y}");
//         // }
//         
//         return neighbours;
//     }
//     
//     List<Vector2Int> FindEmptyNeighbour(Vector2Int pointToCheck)
//        {
//            List<Vector2Int> neighbourPoints = new List<Vector2Int>();
//        
//            for (int x = -1; x <= 1; x++)
//            {
//                for (int y = -1; y <= 1; y++)
//                {
//                    //Skip when x and y == 0 as it the same as the coordinate to check
//                    if (x == 0 && y == 0) continue;
//                    
//                    //Only check in four directions
//                    if (x == y || Mathf.Abs(x - y) == 2) continue;
//            
//                    //The coordinate of a neighbour
//                    int neighbourX = pointToCheck.x + x;
//                    int neighbourY = pointToCheck.y + y;
//            
//                    //Skip when the found neighbour point already has a room
//                    if(grid[neighbourX, neighbourY].isRoom) continue;
//        
//                    //The other neighbour's coordinate must not be less than zero cause the origin point in the array is [0,0]
//                    if (neighbourX >= 0 && neighbourY >= 0)
//                    {
//                        //The neighbour coordinate must stay within the bounds of the grid
//                        if (neighbourX < gridSizeX && neighbourY < gridSizeY)
//                        {
//                            neighbourPoints.Add(new Vector2Int(neighbourX, neighbourY));
//                        }
//                    }
//                }
//            }
//            
//            return neighbourPoints;
//        }
//     
// }
