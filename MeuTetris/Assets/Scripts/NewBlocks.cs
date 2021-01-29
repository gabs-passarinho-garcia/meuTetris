using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlocks : MonoBehaviour
{
   public Transform[] blocks;
    
    public void getNewBlock()
    {
        Instantiate(blocks[0]);
    }

}
