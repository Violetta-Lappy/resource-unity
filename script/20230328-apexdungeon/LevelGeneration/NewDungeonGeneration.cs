using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class NewDungeonGeneration : MonoBehaviour
{
    public static NewDungeonGeneration instance;

    public GameObject player;
    
    [FormerlySerializedAs("walkerManager")] public NewWalkerManager newWalkerManager;
    public Vector3 startRoomPosition;
    
    [Header("Grid generation")] 
    public float roomWidth;
    public float roomLength;
    public int gridSizeX;
    public int gridSizeY;
    private Coordinate middleCoordinate;
    
    
    [Header("Room generation")] 
    public GameObject roomManager;
    
    private Coordinate[,] grid;
    HashSet<Vector2Int> possibleRoomCoordinates;
    private List<RoomSpawner> roomSpawners = new List<RoomSpawner>();
    private List<RoomData> roomManagers = new List<RoomData>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SetUpGrid());
    }
    
    IEnumerator SetUpGrid()
    {
        //Initiate the size of the grid
        grid = new Coordinate[gridSizeX, gridSizeY];

        Vector3 arrayOrigin = transform.position - Vector3.right * ((int)(roomWidth * gridSizeX)) / 2 - Vector3.forward * ((int)(roomLength * gridSizeY)) / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPosition = arrayOrigin + Vector3.right * (x * roomWidth + roomWidth / 2) + Vector3.forward * (y * roomLength + roomLength/2);
                grid[x, y] = new Coordinate(x, y, worldPosition);
                //print(grid[x, y].gridX + " , " + grid[x,y].gridY);
            }
        }

        middleCoordinate = grid[(int) gridSizeX / 2, (int) gridSizeY / 2];

        if (newWalkerManager == null) yield break;
        possibleRoomCoordinates = newWalkerManager.GetVisitedPositions(new Vector2Int(middleCoordinate.gridX,middleCoordinate.gridY));
        
        Vector2Int furthersFromStart = FindFurthestDistanceInHash(new Vector2Int(middleCoordinate.gridX, middleCoordinate.gridY), possibleRoomCoordinates);

        foreach (var c in possibleRoomCoordinates)
        {
            grid[c.x, c.y].isRoom = true;
            
        }

        foreach (var c in possibleRoomCoordinates)
        {
            //Spawn room manager object
            GameObject roomManagerObject = Instantiate(roomManager, grid[c.x, c.y].worldPosition, Quaternion.identity);
            roomManagerObject.transform.parent = transform;
            RoomSpawner roomSpawner = roomManagerObject.GetComponent<RoomSpawner>();
            roomSpawner.positionInGrid = c;
            roomSpawners.Add(roomSpawner);
            
            //Getting desired positions for the door
            roomSpawner.openDoorPositions = GetExpectedDirections(c);
            roomSpawner.closedDoorPositions = GetBlockedDirections(c);  

            if (c == furthersFromStart)
            {
                var i = roomSpawners.IndexOf(roomSpawner);
                roomSpawners[i].SpawnRoom(RoomType.End, roomSpawners[i].transform.position);
                roomSpawners.Remove(roomSpawner);
            }
        }
        
        foreach (var roomSpawner in roomSpawners)
        {
            if (roomSpawner == roomSpawners.First())
            {
                roomSpawner.SpawnRoom(RoomType.Start, roomSpawner.transform.position);
                startRoomPosition = roomSpawner.transform.position;
            }
            else
            {
                roomSpawner.SpawnRoom(RoomType.Normal, roomSpawner.transform.position);
            }

            roomManagers.Add(roomSpawner.spawnedRoom.GetComponent<RoomData>());
            
            yield return new WaitForSeconds(0.01f);
        }

        if (player != null)
        {
            player.transform.position = new Vector3(startRoomPosition.x, startRoomPosition.y + 3f, startRoomPosition.z);

            //Update camera bound for first room
            RoomBoundManager startRoomBound = roomManagers[0].transform.GetComponentInChildren<RoomBoundManager>();
            startRoomBound.UpdateCameraBound();
        }

        MasterGameSystem.Instance.BakeInRunTime();

        if (LevelLoader.Instance != null)
        {
            LevelLoader.Instance.Announce_DungeonDone();
        }
    }

    Vector2Int FindFurthestDistanceInHash(Vector2Int origin, HashSet<Vector2Int> listToFind)
    {
        Vector2Int current = origin;
        
        for (int i = 0; i < listToFind.Count(); i++)
        {
            if (Vector2Int.Distance(origin, current) < Vector2Int.Distance(origin, listToFind.ElementAt(i)))
            {
                current = listToFind.ElementAt(i);
            }
        }

        return current;
    }


    List<DoorPosition> GetExpectedDirections(Vector2Int pointToCheck)
    {
        List<DoorPosition> expectedDirections = new List<DoorPosition>();

        if (grid[pointToCheck.x - 1, pointToCheck.y].isRoom)
        {
            expectedDirections.Add(DoorPosition.Top);
        }

        if (grid[pointToCheck.x + 1, pointToCheck.y].isRoom)
        {
           expectedDirections.Add(DoorPosition.Bot);
        }

        if (grid[pointToCheck.x, pointToCheck.y - 1].isRoom)
        {
            expectedDirections.Add(DoorPosition.Left);
        }

        if (grid[pointToCheck.x, pointToCheck.y + 1].isRoom)
        {
            expectedDirections.Add(DoorPosition.Right);
        }

        return expectedDirections;
    }
    
    List<DoorPosition> GetBlockedDirections(Vector2Int pointToCheck)
    {
        List<DoorPosition> blockedDirections = new List<DoorPosition>();

        if (!grid[pointToCheck.x - 1, pointToCheck.y].isRoom)
        {
            blockedDirections.Add(DoorPosition.Top);
        }

        if (!grid[pointToCheck.x + 1, pointToCheck.y].isRoom)
        {
            blockedDirections.Add(DoorPosition.Bot);
        }

        if (!grid[pointToCheck.x, pointToCheck.y - 1].isRoom)
        {
            blockedDirections.Add(DoorPosition.Left);
        }

        if (!grid[pointToCheck.x, pointToCheck.y + 1].isRoom)
        {
            blockedDirections.Add(DoorPosition.Right);
        }

        return blockedDirections;
    }

    public Vector3 GetWorldPosition(Vector2Int coordinate)
    {
        Vector3 gridToWorld = new Vector3();
        gridToWorld = grid[coordinate.x, coordinate.y].worldPosition;
        return gridToWorld;
    }
    
    // List<Coordinate> FindNeighbours(Coordinate origin)
    // {
    //     List<Coordinate> neighbours = new List<Coordinate>();
    //
    //     //Loop through every coordinate that is the neighbours of the passed in coordinate to check
    //     for (int x = -1; x <= 1; x++)
    //     {
    //         for (int y = -1; y <= 1; y++)
    //         {
    //             //Skip when x and y == 0 as it the same as the coordinate to check
    //             if (x == 0 && y == 0) continue;
    //             
    //             //Only check in four directions
    //             if (x == y || Mathf.Abs(x - y) == 2) continue;
    //
    //             int neighbourX = origin.gridX + x;
    //             int neighbourY = origin.gridY + y;
    //
    //             //The other neighbour's coordinate must not be less than zero cause the origin point in the array is [0,0]
    //             if (neighbourX >= 0 && neighbourY >= 0)
    //             {
    //                 //The neighbour coordinate must stay within the bounds of the grid
    //                 if (neighbourX < gridSizeX && neighbourY < gridSizeY)
    //                 {
    //                     neighbours.Add(grid[neighbourX, neighbourY]);
    //                 }
    //             }
    //         }
    //     }
    //     return neighbours;
    // }
    
    // private void OnDrawGizmos()
    // {
    //     if (grid == null) return;
    //     foreach(var tile in grid)
    //     {
    //         if(tile != null)
    //         {
    //             Gizmos.color = Color.green;
    //             Gizmos.DrawWireCube(tile.worldPosition, new Vector3(roomWidth, 10f, roomLength));
    //         }
    //     }
    // }
}

