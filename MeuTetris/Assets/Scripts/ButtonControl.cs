using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private Moving block = null;

    public void OnDownClick()
    {
        block.goDown();
    }
    
    public void OnUpClick()
    {
        block.rotate();
    }
    public void OnLeftClick()
    {
        block.goLeft();
    }

    public void OnRightClick()
    {
        block.goRight();
    }
    public void SetBlock(Moving block)
    {
        this.block = block;
    }
}
