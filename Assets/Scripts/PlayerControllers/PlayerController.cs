using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    Vector3 pos;                                // For movement
    float speed = 8.0f;                         // Speed of movement

    void Start()
    { 
        
        pos = transform.position;          // Take the initial position
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("MH =" + moveHorizontal.ToString("N0"));
        float moveVertical = Input.GetAxisRaw("Vertical");
        //Debug.Log("MH =" + moveVertical.ToString("N0"));

        //if (Input.GetKeyDown(KeyCode.A) && transform.position == pos)
        if (moveHorizontal == -1 && transform.position == pos)
        {        // Left
            transform.Rotate(0, -90, 0);
            Debug.Log("Rotating Left");
        }
        if (moveHorizontal == 1 && transform.position == pos)
            //if (Input.GetKeyDown(KeyCode.D) && transform.position == pos)
        {        // Right
            transform.Rotate(0, 90, 0);
            Debug.Log("Rotating Right");
        }
        //if (Input.GetKey(KeyCode.W) && transform.position == pos)
        if (moveVertical == 1 && transform.position == pos)
        {        // Up
            pos += transform.forward;
        }
        if (moveVertical == -1 && transform.position == pos)
        //if (Input.GetKey(KeyCode.S) && transform.position == pos)
        {        // Down
            pos += transform.forward * -1;

        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move thereW
    }

}