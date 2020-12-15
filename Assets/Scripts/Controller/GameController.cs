using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timerForDeadCells;//TIME between for cells from HIGHLIGHTED_COLOR to DEAD_COLOR

    List<Cell> AdjacentCell; // It is used to store the all adjancent cell when a user click on any cell.
    bool canTouch =true; //used to check can a user touch the cells or not.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canTouch)
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cast a ray straight down.
            RaycastHit2D hit = Physics2D.Raycast(mousPos, Vector3.forward);

            // If it hits something...
            if (hit.collider != null && hit.collider.GetComponent<Cell>()!=null)
            {
                if (hit.collider.GetComponent<Cell>().IsActive)
                {

                    //print("Yes Something Hit");
                    canTouch = false;
                    StartCoroutine(DeadCells(hit.collider.GetComponent<Cell>().Index));

                }

            }

        }
    }

    IEnumerator DeadCells(Vector2 _index)
    {
        AdjacentCell = new List<Cell>();
        SetDigonalCellHighlighted(BoardGenerator.instance.board.AllCells, (int)_index.x, (int)_index.y);
        yield return new WaitForSeconds(timerForDeadCells);
        SetDigonalCellDead();
        canTouch = true;//Now user is able to touch the another cell

        if(WiningManager.instance!=null)
        WiningManager.instance.CheckWining(BoardGenerator.instance.board.AllCells);
    }

    void SetDigonalCellDead()
    {
        foreach (var cell in AdjacentCell)
        {
            cell.SR.color = BoardView.instance.cellColorInfo.deadCellColor;
        }
    }

    void SetDigonalCellHighlighted(Cell[,] Cells, int _row, int _col)
    {

        int row = _row;
        int col = _col;

        Cells[row, col].IsActive = false;
        Cells[row, col].SR.color = BoardView.instance.cellColorInfo.selectedCellColor;
        AdjacentCell.Add(Cells[row, col]);

        while (true)//TopRight
        {
            row++;
            col++;
            if (!HasThisCellHighlighted(Cells, row, col))
                break;
        }
        row = _row;
        col = _col;
        while (true)//TopLeft
        {
            row--;
            col++;
            if (!HasThisCellHighlighted(Cells, row, col))
                break;
        }
        row = _row;
        col = _col;
        while (true)//DownLeft
        {
            row--;
            col--;
            if (!HasThisCellHighlighted(Cells, row, col))
                break;
        }
        row = _row;
        col = _col;
        while (true)//DownRight
        {
            row++;
            col--;
            if (!HasThisCellHighlighted(Cells, row, col))
                break;
        }
        

    }
        
    bool HasThisCellHighlighted(Cell[,] Cells, int row, int col)
    {
        if (!IsInBoudary(Cells, row, col)) //these are check to boundary blocks
        {
            return false;
        }
        if (!Cells[row, col].IsActive) // If current cell is already dead then break the condition;
        {
            return false;
        }

        Cells[row, col].IsActive = false;
        Cells[row, col].SR.color = BoardView.instance.cellColorInfo.highlightedCellColor;
        AdjacentCell.Add(Cells[row, col]);
        return true;
    }

    bool IsInBoudary(Cell[,] Cells,int row,int col)
    {
        if (row < 0 || col < 0 || row >= Cells.GetLength(0) || col >= Cells.GetLength(1)) //these are check to boundary blocks
            return false;

        return true;
    }

}