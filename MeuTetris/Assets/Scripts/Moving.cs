using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour{

    private float counter = 0;
    private int speed = 1;
    private Vector3 velocity = new Vector3(0, 0, 0);
    public bool moving = true;
    private int heigth = 20;
    private int width = 10;
    private Control con;
    private ButtonControl bc;
    private NewBlocks newer;
    public bool rotating = true;

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
        if ((Time.time - counter) >= 1 && moving)
        {
            transform.position += new Vector3(0, -speed, 0);
            counter = Time.time;
            if (!con.insideBorders(this))
            {
                transform.position += new Vector3(0, speed, 0);
                setMoving(false);
                rotating = false;
                newer.GetNewBlock();
            }
        }
        
    }
    public void setMoving(bool active){
        this.moving = active;
    }
    public void goRight()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (!con.insideBorders(this))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
    }
    public void goLeft()
    {
        transform.position += new Vector3(-speed, 0, 0);
        if (!con.insideBorders(this))
        {
            transform.position += new Vector3(+speed, 0, 0);
        }
    }
    public void goDown()
    {
        transform.position += new Vector3(0, -speed, 0);
        if (!con.insideBorders(this))
        {
            transform.position += new Vector3(0, speed, 0);
            setMoving(false);
            rotating = false;
            newer.GetNewBlock();
        }
    }
    public void rotate()
    {
        if (rotating)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
    
}
