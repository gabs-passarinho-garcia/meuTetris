using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private Moving block;
    // Start is called before the first frame update
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

    public void onRightClick()
    {
        block.goRight();
    }
    public void setBlock(Moving block)
    {
        this.block = block;
    }
}
