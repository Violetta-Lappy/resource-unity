using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWalker
{
   public Vector2Int currentPosition { get; set; }

   //Parameterized constructor
   public NewWalker(Vector2Int startPosition)
   {
      currentPosition = startPosition;
   }

   public Vector2Int Move(Dictionary<WalkerDirection, Vector2Int> walkerMoveDir)
   {
      GetNewPosition(walkerMoveDir);
      
      return currentPosition;
   }

   private void GetNewPosition(Dictionary<WalkerDirection, Vector2Int> walkerMoveDir)
   {
      WalkerDirection moveDirection = (WalkerDirection) Random.Range(0, walkerMoveDir.Count);
      var previousPosition = currentPosition;
      currentPosition = previousPosition + walkerMoveDir[moveDirection];
   }
}
