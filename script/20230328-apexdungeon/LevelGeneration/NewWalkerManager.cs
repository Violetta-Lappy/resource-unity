using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum WalkerDirection
{
    top,down,left,right
}

public class NewWalkerManager : MonoBehaviour
{
    [Range(1,6)]
    public int numberOfWalkers = 1;
    public int numberOfIterations = 10;
    public int totalNumberOfRoom;

    HashSet<Vector2Int> allVisitedCoordinate = new HashSet<Vector2Int>();
    
    [Tooltip("If this is enabled, the shape of the level is more complex and spaced out")]
    public bool randomStartPosition = false;
    
    // private static readonly Dictionary<WalkerDirection, Coordinate> walkerMoveDir =
    //     new Dictionary<WalkerDirection, Coordinate>()
    //     {
    //         {WalkerDirection.top, Coordinate.up},
    //         {WalkerDirection.down, Coordinate.down},
    //         {WalkerDirection.left, Coordinate.left},
    //         {WalkerDirection.right, Coordinate.right}
    //     };
    
    private static readonly Dictionary<WalkerDirection, Vector2Int> walkerMoveDir =
        new Dictionary<WalkerDirection, Vector2Int>()
        {
            {WalkerDirection.top, Vector2Int.up},
            {WalkerDirection.down, Vector2Int.down},
            {WalkerDirection.left, Vector2Int.left},
            {WalkerDirection.right, Vector2Int.right}
        };
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        totalNumberOfRoom = numberOfWalkers * numberOfIterations;
    }
#endif

    public HashSet<Vector2Int> MakePath(Vector2Int startPosition, int walkLength)
    {
        //Create new newWalker instance
        NewWalker newWalker = new NewWalker(startPosition);
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        
        
        for (int i = 0; i < walkLength; i++)
        {
            if (allVisitedCoordinate.Count >= totalNumberOfRoom) continue;

            Vector2Int newPosition = newWalker.Move(walkerMoveDir);
            // print($"NewWalker coordinate ({newPosition.gridX},{newPosition.gridY})");
            path.Add(newPosition);
            
        }
        return path;
    }

    //Hashset just list but faster when there are multiple elements
    public HashSet<Vector2Int> GetVisitedPositions(Vector2Int startPosition)
    {
        var currentPosition = startPosition;
        // HashSet<Vector2Int> allVisitedCoordinate = new HashSet<Vector2Int>();
        for (int i = 0; i < numberOfWalkers; i++)
        {
            var path = MakePath(currentPosition, numberOfIterations);
            //Dont copy duplicate
            allVisitedCoordinate.UnionWith(path);

            if (randomStartPosition)
            {
                currentPosition =
                    allVisitedCoordinate.ElementAt(UnityEngine.Random.Range(0, allVisitedCoordinate.Count));
            }
        }

        while (allVisitedCoordinate.Count < totalNumberOfRoom)
        {
            for (int i = 0; i < numberOfWalkers; i++)
            {
                var path = MakePath(currentPosition, numberOfIterations);
                //Dont copy duplicate
                allVisitedCoordinate.UnionWith(path);

                if (randomStartPosition)
                {
                    currentPosition =
                        allVisitedCoordinate.ElementAt(UnityEngine.Random.Range(0, allVisitedCoordinate.Count));
                }
            }
        }
        
        return allVisitedCoordinate;
        // List<NewWalker> walkers = new List<NewWalker>();
        // HashSet<Coordinate> visitedPositions = new HashSet<Coordinate>();
        //
        // for (int i = 0; i < numberOfWalkers; i++)
        // {
        //     //Create new walker
        //     walkers.Add(new NewWalker(startPosition));
        // }
        //
        // foreach (var w in walkers)
        // {
        //     for (int i = 0; i < numberOfIterations; i++)
        //     {
        //         Coordinate newPosition = w.Move(walkerMoveDir);
        //         // print($"NewWalker coordinate ({newPosition.gridX},{newPosition.gridY})");
        //         visitedPositions.Add(newPosition);
        //     }
        // }
        //
        // foreach (var position in visitedPositions)
        // {
        //     print($"({position.gridX},{position.gridY})");
        // }
        // return visitedPositions;
    }


}
