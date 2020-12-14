using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    public static BoardView instance;
    public Cell Cell;

    public Color selectedCellColor;
    public Color activeCellColor;
    public Color highlightedCellColor;
    public Color deadCellColor;

    public float gapWidth;



    void Awake() => instance = this;
     
    /// <summary>
    /// Set the gameboard view
    /// </summary>
    public void DrawGameBoard(ref Board _board)
    {

        for (int i = 0; i < _board.col; i++)
        {
            for (int j = 0; j < _board.row; j++)
            {
                GameObject cell_obj = Instantiate(Cell.gameObject);
                cell_obj.transform.position = new Vector3(i + (i * gapWidth), (j + (j * gapWidth))); // setting the position
                cell_obj.GetComponent<Cell>().Initialize(new Vector2(i, j), activeCellColor); // assinging the initial color to the cell
                _board.AllCells[i, j] = cell_obj.GetComponent<Cell>();//Assigning the cell into the board cell index
            }
        }

        SetGridInCentring(_board);
    }

    [ContextMenu("SetGridCentering")]
    private void SetGridInCentring(Board _board)
    {
        float y = ((_board.row - 1) + ((_board.row - 1) * gapWidth)) / 2;
        float x = ((_board.col - 1) + ((_board.col - 1) * gapWidth)) / 2;
        Vector2 center = new Vector2(x, y);

        GameObject CenterParent = new GameObject();

        CenterParent.transform.position = center;
        //CenterParent.transform.localScale = new Vector2(col + col * gapWidth, row + row * gapWidth);
        for (int i = 0; i <_board.col; i++)
        {
            for (int j = 0; j <_board.row; j++)
            {
                _board.AllCells[i, j].transform.SetParent(CenterParent.transform);
            }

        }
        CenterParent.transform.position = new Vector2(0f, 0f);
    }
}
