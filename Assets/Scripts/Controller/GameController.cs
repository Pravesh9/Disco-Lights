using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timerForDeadCells;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cast a ray straight down.
            RaycastHit2D hit = Physics2D.Raycast(mousPos, Vector3.forward);

            // If it hits something...
            if (hit.collider != null && hit.collider.GetComponent<Cell>()!=null)
            {
                if (hit.collider.GetComponent<Cell>().IsActive)
                {

                    print("Yes Something Hit");
                    StartCoroutine(DeadCells(hit.collider.GetComponent<Cell>().Index));

                }

            }

        }
    }

    IEnumerator DeadCells(Vector2 _index)
    {
        yield return new WaitForSeconds(timerForDeadCells);
        SetDigonalCellDead(BoardGenerator.instance.board.AllCells, (int)_index.x, (int)_index.y);

    }

    public  void SetDigonalCellDead(Cell[,] Cells, int row, int col)
    {
        if (row < 0 || col < 0 || row >= Cells.GetLength(0) || col >= Cells.GetLength(1)) //these are check to boundary blocks
        {
            return;
        }
        if (!Cells[row, col].IsActive)
        {
            return;
        }

        Cells[row, col].IsActive = false;
        Cells[row, col].SR.color = BoardView.instance.cellColorInfo.highlightedCellColor;

        print($"{row},{col}");
        for (int r = row - 1; r <= row + 1; r++)
        {
            for (int c = col - 1; c <= col + 1; c++)
            {

                //if take digonal(r!=row||c!=col)  and if without digonal(r==row||c==col)


                if(r != row && c != col)
                {

                    SetDigonalCellDead(Cells, r, c);
        
        
                }
                
            }

        }
        
    }

}
