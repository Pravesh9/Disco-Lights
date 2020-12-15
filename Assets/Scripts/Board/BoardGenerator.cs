using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public static BoardGenerator instance;
    [Range(2,10)]
    public int row;
    [Range(2, 10)]
    public int col;

    public Board board;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindObjectOfType<Data>() != null)
        {
            row = Data.row;
            col = Data.col;
        }

        board = new Board(row, col);
        BoardView.instance.DrawGameBoard(ref board);
    }

    
}
