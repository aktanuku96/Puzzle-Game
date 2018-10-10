using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeController : MonoBehaviour {

    // Use this for initialization
    Vector2 direction = Vector2.down;
	void Start () {
        InvokeRepeating("Move", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.DownArrow))
            direction = -Vector2.up;
        else if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector2.up;
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;
    }

    void Move()
    {
        transform.Translate(direction);
    }
}
