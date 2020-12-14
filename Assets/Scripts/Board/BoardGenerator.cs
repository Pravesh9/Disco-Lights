using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public int row;
    public int col;

    public Board board;


    // Start is called before the first frame update
    void Start()
    {
        board = new Board(row, col);
        BoardView.instance.DrawGameBoard(ref board);
    }

    
}
