using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Direction> OnDirectionPressed = (dir) => { };

    public enum Direction
    {
        NONE,
        LEFT,
        RIGHT
    }

    public void Init()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnDirectionPressed(Direction.LEFT);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnDirectionPressed(Direction.RIGHT);
        }
    }
}
