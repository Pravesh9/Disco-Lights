using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board 
{
    public readonly int row; //Rows in a board
    public readonly int col;//Cols ina a board
    public Cell[,] AllCells;
    
    public Board(int _row,int _col)
    {
        row = _row;
        col = _col;
        AllCells = new Cell[col, row];
    }

}
