using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour{

    private float counter = 0;
    private readonly int speed = 1;
    private Vector3 velocity = new Vector3(0, 0, 0);
    public bool moving = false;
    private int heigth = 20;
    private int width = 10;
    private Control con;
    private ButtonControl bc;
    private NewBlocks newer;
    public bool rotating = false;

    // Start is called before the first frame update
    void Start(){
        counter = Time.time;
        con = FindObjectOfType<Control>();
        bc = FindObjectOfType<ButtonControl>();
        bc.SetBlock(this);
        newer = FindObjectOfType<NewBlocks>();
    }

    // Update is called once per frame
    void Update(){
        if (moving && (Time.time - counter) >= 1)
        {
            transform.position += new Vector3(0, -speed, 0);
            counter = Time.time;
            if (!con.InsideBorders(this))
            {
                Debug.Log("Parei aqui");
                transform.position += new Vector3(0, speed, 0);
                SetMoving(false);
                rotating = false;
                newer.GetNewBlock();
                con.UpdatePosition(this);
            } else if (con.Collided(this))
            {
                Debug.Log("E eu aqui");
                transform.position += new Vector3(0, speed, 0);
                SetMoving(false);
                rotating = false;
                newer.GetNewBlock();
                con.UpdatePosition(this);
                GameOver();
            }
        }
        
    }
    public void SetMoving(bool active){
        this.moving = active;
    }
    public void GoRight()
    {
        if (moving)
        {
            transform.position += new Vector3(speed, 0, 0);
            if (!con.InsideBorders(this))
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
            else if (con.Collided(this))
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
        }
    }
    public void GoLeft()
    {
        if (moving)
        {
            transform.position += new Vector3(-speed, 0, 0);
            if (!con.InsideBorders(this))
            {
                transform.position += new Vector3(+speed, 0, 0);
            }
            else if (con.Collided(this))
            {
                Debug.Log("Está dando ruim aqui");
                transform.position += new Vector3(+speed, 0, 0);
            }
        }
    }
    public void GoDown()
    {
        if (moving)
        {
            transform.position += new Vector3(0, -speed, 0);
            if (!con.InsideBorders(this))
            {
                transform.position += new Vector3(0, speed, 0);
                SetMoving(false);
                rotating = false;
                newer.GetNewBlock();
                con.UpdatePosition(this);
            }
            else if (con.Collided(this))
            {
                transform.position += new Vector3(0, speed, 0);
                SetMoving(false);
                rotating = false;
                newer.GetNewBlock();
                con.UpdatePosition(this);
                GameOver();
            }
        }
    }

    public void Rotate()
    {
        if (rotating)
        {
            transform.Rotate(0, 0, 90);
            if (!con.InsideBorders(this))
            {
                transform.Rotate(0,0,-90);
            }
            else if (con.Collided(this))
            {
                transform.Rotate(0,0,-90);
            }

        }
    }
    public void SetRotation(bool active)
    {
        this.rotating = active;
    }

    public void GameOver()
    {
        if (!moving)
        {
            foreach (Transform block in transform)
            {
                if (block.position.y > heigth - 1)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
