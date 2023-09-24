using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************
Author: NGUYEN TRAN HA MY
Date mode: 6/10/2021
Object(s) holding this script: GameGrid
Summary: 
Instantiate a grid of cells
***************************/

public class Grid : MonoBehaviour
{
    public int height = 5;
    public int width = 5;
    public GameObject gridCellPrefab;
    public GridCell[,] cells;

    // Start is called before the first frame update
    void Start()
    {
        cells = new GridCell[width, height];

        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create a grid and cell grids
    void CreateGrid()
    {

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject cellGrid = Instantiate(gridCellPrefab, new Vector3(i, 0, j), Quaternion.identity);

                //set name for cells
                cellGrid.name = "Cell (" + i + ",0," + j + ")";

                //store cellGrid in appropriate position in array
                cells[i, j] = cellGrid.GetComponent<GridCell>();

                //parent cellGrids to GameGrid GameObject
                cellGrid.transform.parent = transform;

                //Call GridCell.Init()
                cells[i, j].Init(i, j);
            }
        }
    }
}
