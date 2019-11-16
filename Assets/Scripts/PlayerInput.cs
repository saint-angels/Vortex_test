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
    
    private Direction direction = Direction.NONE;
    
    public void Init()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Direction.LEFT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Direction.RIGHT;
        }
        else
        {
            direction = Direction.NONE;
        }

        OnDirectionPressed(direction);
    }
}
