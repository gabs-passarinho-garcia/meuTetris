using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlocks : MonoBehaviour
{
   public GameObject[] blocks;

    private void Start()
    {
        GetNewBlock();
    }

    public void GetNewBlock()
    {
        Instantiate(blocks[0],transform.position,Quaternion.identity);
    }

}
