using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewCellColorInfo",menuName ="CellColorInfo")]
public class CellColorInfo : ScriptableObject
{
    public Color selectedCellColor;
    public Color activeCellColor;
    public Color highlightedCellColor;
    public Color deadCellColor;

}
