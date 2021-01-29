using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour{

    private float counter = 0;
    private int speed = 2;
    private Vector3 velocity = new Vector3(0, 0, 0);
    private bool moving = true;
    private int heigth = 20;
    private int width = 10;
    private Control con;
    // Start is called before the first frame update
    void Start(){
        counter = Time.time;
        con = FindObjectOfType<Control>();
    }

    // Update is called once per frame
    void Update(){
        velocity = new Vector3(0, 0, 0);
        if ((Time.time - counter) >= 1 && moving)
        {
            velocity.y = -speed;
            counter = Time.time;
        }
        transform.position += velocity;
        
        if (!con.insideBorders(this))
        {
            transform.position -= velocity;
        }
        else
        {
            Control.table[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)] = transform;
            Control.table[Mathf.RoundToInt(transform.position.x - velocity.x), Mathf.RoundToInt(transform.position.y - velocity.y)] = null;
        }
    }
    public void setMoving(bool active){
        this.moving = active;
    }
    
}
