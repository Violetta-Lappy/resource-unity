// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
//
// public class DungeonGeneration : MonoBehaviour
// {
//     public static DungeonGeneration instance;
//
//     public GameObject player;
//     
//     public WalkerManager walkerManager;
//     public Vector3 startRoomPosition;
//     
//     [Header("Grid generation")] 
//     public float roomWidth;
//     public float roomLength;
//     public int gridSizeX;
//     public int gridSizeY;
//     private Coordinate middleCoordinate;
//     
//     
//     [Header("Room generation")] 
//     public GameObject roomManager;
//     
//     private Coordinate[,] grid;
//     private List<Coordinate> possibleRoomCoordinates = new List<Coordinate>();
//     private List<RoomSpawner> roomSpawners = new List<RoomSpawner>();
//     private List<RoomManager> roomManagers = new List<RoomManager>();
//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }
//         else
//         {
//             Destroy(this.gameObject);
//         }
//     }
//
//     void Start()
//     {
//         StartCoroutine(SetUpGrid());
//     }
//     
//     IEnumerator SetUpGrid()
//     {
//         //Initiate the size of the grid
//         grid = new Coordinate[gridSizeX, gridSizeY];
//
//         Vector3 arrayOrigin = transform.position - Vector3.right * ((int)(roomWidth * gridSizeX)) / 2 - Vector3.forward * ((int)(roomLength * gridSizeY)) / 2;
//
//         for (int x = 0; x < gridSizeX; x++)
//         {
//             for (int y = 0; y < gridSizeY; y++)
//             {
//                 Vector3 worldPosition = arrayOrigin + Vector3.right * (x * roomWidth + roomWidth / 2) + Vector3.forward * (y * roomLength + roomLength/2);
//                 grid[x, y] = new Coordinate(x, y, worldPosition);
//                 //print(grid[x, y].gridX + " , " + grid[x,y].gridY);
//             }
//         }
//
//         middleCoordinate = grid[(int) gridSizeX / 2, (int) gridSizeY / 2];
//
//         if (walkerManager == null) yield break;
//         possibleRoomCoordinates = walkerManager.GetVisitedPositions(middleCoordinate);
//             
//         foreach (var c in possibleRoomCoordinates)
//         {
//             c.worldPosition = grid[c.gridX, c.gridY].worldPosition;
//             GameObject roomManagerObject = Instantiate(roomManager, c.worldPosition, Quaternion.identity);
//             roomSpawners.Add(roomManagerObject.GetComponent<RoomSpawner>());
//         }
//
//         foreach (var roomSpawner in roomSpawners)
//         {
//             if (roomSpawner == roomSpawners.First())
//             {
//                 roomSpawner.SpawnRoom(RoomType.Start, roomSpawner.transform.position);
//                 startRoomPosition = roomSpawner.transform.position;
//             }
//             else if(roomSpawner == roomSpawners.Last())
//             {
//                 roomSpawner.SpawnRoom(RoomType.End, roomSpawner.transform.position);
//             }
//             else
//             {
//                 roomSpawner.SpawnRoom(RoomType.Normal, roomSpawner.transform.position);
//             }
//
//             roomManagers.Add(roomSpawner.spawnedRoom.GetComponent<RoomManager>());
//             
//             yield return new WaitForSeconds(0.03f);
//         }
//
//         if (player != null)
//         {
//             player.transform.position = new Vector3(startRoomPosition.x, startRoomPosition.y + 3f, startRoomPosition.z);
//         }
//     }
//     
//
//     // List<Coordinate> FindNeighbours(Coordinate origin)
//     // {
//     //     List<Coordinate> neighbours = new List<Coordinate>();
//     //
//     //     //Loop through every coordinate that is the neighbours of the passed in coordinate to check
//     //     for (int x = -1; x <= 1; x++)
//     //     {
//     //         for (int y = -1; y <= 1; y++)
//     //         {
//     //             //Skip when x and y == 0 as it the same as the coordinate to check
//     //             if (x == 0 && y == 0) continue;
//     //             
//     //             //Only check in four directions
//     //             if (x == y || Mathf.Abs(x - y) == 2) continue;
//     //
//     //             int neighbourX = origin.gridX + x;
//     //             int neighbourY = origin.gridY + y;
//     //
//     //             //The other neighbour's coordinate must not be less than zero cause the origin point in the array is [0,0]
//     //             if (neighbourX >= 0 && neighbourY >= 0)
//     //             {
//     //                 //The neighbour coordinate must stay within the bounds of the grid
//     //                 if (neighbourX < gridSizeX && neighbourY < gridSizeY)
//     //                 {
//     //                     neighbours.Add(grid[neighbourX, neighbourY]);
//     //                 }
//     //             }
//     //         }
//     //     }
//     //     return neighbours;
//     // }
//     
//     // private void OnDrawGizmos()
//     // {
//     //     if (grid == null) return;
//     //     foreach(var tile in grid)
//     //     {
//     //         if(tile != null)
//     //         {
//     //             Gizmos.color = Color.green;
//     //             Gizmos.DrawWireCube(tile.worldPosition, new Vector3(roomWidth, 10f, roomLength));
//     //         }
//     //     }
//     // }
// }
//
