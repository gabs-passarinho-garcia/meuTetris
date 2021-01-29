using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static int height = 20;
    public static int width = 10;
    public static Transform[,] table = new Transform[width, height];
    private NewBlocks newer;

    public bool insideBorders(Moving blocks)
    {
        foreach (Transform block in blocks.transform) {
            if (block.transform.position.y < 0) {
                blocks.setMoving(false);
                newer.getNewBlock();
                return false;
            } else if (block.transform.position.x < 0)
            {
                return false;
            } else if (block.transform.position.x > width)
            {
                return false;
            } else if (block.transform.position.y < height && block.transform.position.y >= 0)
            {
                if (table[Mathf.RoundToInt(block.transform.position.x), Mathf.RoundToInt(block.transform.position.y)] != null)
                {
                    if (table[Mathf.RoundToInt(block.transform.position.x), Mathf.RoundToInt(block.transform.position.y)] != block)
                    {
                        blocks.setMoving(false);
                        newer.getNewBlock();
                        return false;
                    }
                }
            }
        }
        return true;
    }
    private void Start()
    {
       newer = FindObjectOfType<NewBlocks>();
       newer.getNewBlock();
    }
}
