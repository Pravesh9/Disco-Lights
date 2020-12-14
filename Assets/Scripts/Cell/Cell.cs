using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    public Vector2 Index;
    public bool IsActive;
    
    

    private Color initalColor;
    public SpriteRenderer SR;

    
    
    void Start()
    {
        
    }

    public void Initialize(Vector2 _index,Color _initialCol)
    {
        Index = _index;
        initalColor = _initialCol;

        SR.color = initalColor;

    }

}
