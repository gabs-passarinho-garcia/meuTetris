using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private Moving block = null;

    public void OnDownClick()
    {
        block.GoDown();
    }
    
    public void OnUpClick()
    {
        block.Rotate();
    }
    public void OnLeftClick()
    {
        block.GoLeft();
    }

    public void OnRightClick()
    {
        block.GoRight();
    }
    public void SetBlock(Moving block)
    {
        this.block = block;
    }
}
