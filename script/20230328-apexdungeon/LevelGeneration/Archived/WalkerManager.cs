// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
//
// public enum WalkerDirection
// {
//     top,down,left,right
// }
//
// public class WalkerManager : MonoBehaviour
// {
//     [Range(1,6)]
//     public int numberOfWalkers = 1;
//     public int numberOfIterations;
//     public int totalNumberOfRoom;
//
//     private static readonly Dictionary<WalkerDirection, Coordinate> walkerMoveDir =
//         new Dictionary<WalkerDirection, Coordinate>()
//         {
//             {WalkerDirection.top, Coordinate.up},
//             {WalkerDirection.down, Coordinate.down},
//             {WalkerDirection.left, Coordinate.left},
//             {WalkerDirection.right, Coordinate.right}
//         };
//     
// #if UNITY_EDITOR
//     private void OnValidate()
//     {
//         totalNumberOfRoom = numberOfWalkers * numberOfIterations;
//     }
// #endif
//
//     //Hashset just list but faster when there are multiple elements
//     public List<Coordinate> GetVisitedPositions(Coordinate startPosition)
//     {
//         List<Walker> walkers = new List<Walker>();
//         List<Coordinate> visitedPositions = new List<Coordinate>();
//
//         for (int i = 0; i < numberOfWalkers; i++)
//         {
//             //Create new walker
//             walkers.Add(new Walker(startPosition));
//         }
//         foreach (var w in walkers)
//         {
//             for (int i = 0; i < numberOfIterations; i++)
//             {
//                 Coordinate newPosition = w.Move(walkerMoveDir, visitedPositions);
//                 // print($"Walker coordinate ({newPosition.gridX},{newPosition.gridY})");
//                 visitedPositions.Add(newPosition);
//             }
//         }
//         return visitedPositions;
//     }
//
//
// }
