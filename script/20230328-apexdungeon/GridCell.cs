using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 6/10/2021
Object(s) holding this script: GridCell
Summary: 
Assign xIndex and zIndex to the cell
Print the position of the cell when the mouse click on
***************************/

public class GridCell : MonoBehaviour
{
    public int xIndex;
    public int zIndex;

    //Assign xIndex and zIndex to variables passed in
    //Called by Grid.CreateGrid()
    public void Init(int x, int z)
    {
        xIndex = x;
        zIndex = z;
    }

    //Show the position of the cell clicked by the mouse
    private void OnMouseDown()
    {
        Debug.Log("Clicked on cell(" + xIndex + ",0," + zIndex + ")");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
