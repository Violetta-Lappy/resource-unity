using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //To display in Editor as debug
public class Coordinate
{
    public bool isRoom = false;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    // public List<DoorPosition> expectedDoorPositions;
    // public List<DoorPosition> blockedDoorPositions;

    //A parameterized constructor to assign initial values to the data members of the same class, in this case the Coordinate class
    //can be understand easily as a method overloading for creating new instance of Coordinate
    public Coordinate(int _gridX, int _gridY, Vector3 _worldPosition = default)
    {
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
    }
    
    public static Coordinate CoordinateAddition(Coordinate a, Coordinate b)
    {
        return new Coordinate(a.gridX + b.gridX, a.gridY +b.gridY);
    }

    public static bool IsEqual(Coordinate a, Coordinate b)
    {
        return a.gridX == b.gridX && a.gridY == b.gridY;
    }
    
    public bool VisitedCoordinate(Coordinate coordinate, List<Coordinate> allCoors)
    {
        if (allCoors.Count == 0) return false;
        
        foreach (var t in allCoors)
        {
            if (IsEqual(coordinate, t))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsCoordinateInBound(Coordinate coordinate, int xBound, int yBound)
    {
        if (coordinate.gridX >= 0 && coordinate.gridY >= 0)
        {
            return coordinate.gridX < xBound && coordinate.gridY < yBound;
        }
        
        return false;
    }
    
    private static readonly Coordinate upDirection = new Coordinate(0,1);
    private static readonly Coordinate downDirection = new Coordinate(0,-1);
    private static readonly Coordinate leftDirection = new Coordinate(-1,0);
    private static readonly Coordinate rightDirection = new Coordinate(1,0);

    public static Coordinate up => upDirection;
    public static Coordinate down => downDirection;
    public static Coordinate left => leftDirection;
    public static Coordinate right => rightDirection;
}

public enum DoorPosition {Top, Bot, Left, Right, None}