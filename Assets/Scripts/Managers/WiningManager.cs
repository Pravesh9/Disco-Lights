using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiningManager : MonoBehaviour
{
    public static WiningManager instance;

    private void Awake() => instance = this;

    public void CheckWining(Cell[,] cells)
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (cells[i, j].IsActive)
                {
                    return; //It means There is some cell remaining which is still alive.
                }
            }
        }
        if(GameManager.instance!=null)
        GameManager.instance.PlayerWon();
    }


}
