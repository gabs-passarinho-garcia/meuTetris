using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public static int height = 20;
    public static int width = 10;
    public Transform[,] table = new Transform[width, height];
    public int score = 0;
    public Text scoring;
    public readonly int point = 100;

    private void Update()
    {
        scoring.text = "Score:\n" + score.ToString();
        for (int i = 0; i < Control.height; i++)
        {
            if (FullLine(i))
            {
                score += point;
                DestroyLine(i);
                UpdateTable(i);
            }
        }

    }
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
                if (table[Mathf.RoundToInt(block.position.x), Mathf.RoundToInt(block.position.y)] != null)
                {
                    return true;
                }
            }
        }
        return false;

    }
    public void UpdatePosition(Moving blocks)
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
    public bool FullLine(int y)
    {
        for (int x = 0; x < Control.width; x++)
        {
            if (table[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }
    public void DestroyLine(int y)
    {
        for(int x = 0; x < Control.width; x++)
        {
            Destroy(table[x, y].gameObject);
        }
    }
    public void UpdateTable(int j)
    {
        for (int y = j; y < (Control.height - 1); y++)
        {
            for(int x = 0; x < Control.width; x++)
            {
                table[x , y] = table[x , y + 1];
                if (table[x,y] != null)
                {
                    table[x, y].position += new Vector3(0, -1, 0);
                }
            }
        }
        for (int x = 0; x < Control.width; x++)
        {
            table[x, Control.height - 1] = null;
        }
    }

}
