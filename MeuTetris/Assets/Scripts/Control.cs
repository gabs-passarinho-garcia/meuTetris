using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static int height = 20;
    public static int width = 10;
    public static Transform[,] table = new Transform[width, height];

    public bool InsideBorders(Moving blocks)
    {
        foreach (Transform block in blocks.transform) {
            if (block.transform.position.y < 0) {
                return false;
            } else if (block.transform.position.x < 0)
            {
                return false;
            } else if (block.transform.position.x > width)
            {
                return false;
            }
        }
        return true;
    }

    public bool Collided(Moving blocks)
    {
        foreach (Transform block in blocks.transform)
        {
            if (block.position.x > -1 && block.position.x < Control.width && block.position.y > -1 && block.position.y < Control.height)
            {
                if(table[Mathf.RoundToInt(block.position.x), Mathf.RoundToInt(block.position.y)] != null)
                {
                    return true;
                }
            }
        }
        return false;

    }
    public static void UpdatePosition(Moving blocks)
    {
        foreach (Transform block in blocks.transform)
        {
            if (block.position.x > -1 && block.position.x < Control.width && block.position.y > -1 && block.position.y < Control.height)
            {
                if (table[Mathf.RoundToInt(block.position.x), Mathf.RoundToInt(block.position.y)] == null)
                {
                    table[Mathf.RoundToInt(block.position.x), Mathf.RoundToInt(block.position.y)] = block.transform;
                }
            }
        }
    }

}
