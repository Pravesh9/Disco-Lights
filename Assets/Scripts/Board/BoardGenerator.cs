using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [Range(2,10)]
    public int row;
    [Range(2, 10)]
    public int col;

    Board board;


    // Start is called before the first frame update
    void Start()
    {
        board = new Board(row, col);
        BoardView.instance.DrawGameBoard(ref board);
    }

    
}
