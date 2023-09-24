// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Walker
// {
//    public Coordinate currentPosition { get; set; }
//
//    //Parameterized constructor
//    public Walker(Coordinate startPosition)
//    {
//       currentPosition = startPosition;
//    }
//
//    public Coordinate Move(Dictionary<WalkerDirection, Coordinate> walkerMoveDir, List<Coordinate> listToCheck)
//    {
//       GetNewPosition(walkerMoveDir, listToCheck);
//       
//       return currentPosition;
//    }
//
//    private void GetNewPosition(Dictionary<WalkerDirection, Coordinate> walkerMoveDir,  List<Coordinate> listToCheck)
//    {
//       int currentLoop = 0;
//       int maxLoops = 20;
//       WalkerDirection moveDirection = (WalkerDirection) Random.Range(0, walkerMoveDir.Count);
//       currentPosition = Coordinate.CoordinateAddition(currentPosition, walkerMoveDir[moveDirection]);
//
//       while (currentLoop <= maxLoops && (currentPosition.VisitedCoordinate(currentPosition,listToCheck) 
//                                          || !currentPosition.IsCoordinateInBound(currentPosition, DungeonGeneration.instance.gridSizeX, DungeonGeneration.instance.gridSizeY)))
//       {
//          currentLoop++;
//          if (currentLoop < maxLoops)
//          {
//             GetNewPosition(walkerMoveDir, listToCheck);
//          }
//          else
//          {
//             //Find a random room and start move at that room
//             
//          }
//       }
//    }
// }
