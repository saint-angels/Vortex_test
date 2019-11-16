using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform playerShell;
    [SerializeField] private Transform playerModel;

    private float _angle;
    private GeneralConfig generalConfig;

    //From -1(max left) to 1(max right)
    private float roll;

    private PlayerInput.Direction lastPressedDirection;
    
    public void Init()
    {
        generalConfig = Root.ConfigManager.GeneralConfig;
        GetComponent<PlayerInput>().OnDirectionPressed += DirectionPressed;

        lastPressedDirection = PlayerInput.Direction.NONE;
    }

    private void DirectionPressed(PlayerInput.Direction direction)
    {
        
        
        float mult = 0;
        switch (direction)
        {
            case PlayerInput.Direction.LEFT:
                mult = -1;
                break;
            case PlayerInput.Direction.RIGHT:
                mult = 1;
                break;
        }

        float rollDelta = generalConfig.rollSpeed * Time.deltaTime;
        switch (direction)
        {
            case PlayerInput.Direction.NONE:
                roll = Mathf.MoveTowards(roll, 0, rollDelta);
                break;
            case PlayerInput.Direction.LEFT:
            case PlayerInput.Direction.RIGHT:
                roll = Mathf.Clamp(roll + mult * rollDelta * -1f, -1f, 1f);
                
                break;
        }

        playerModel.rotation = Quaternion.Euler(0, 0, generalConfig.rollMaxAngle * roll);


        _angle += generalConfig.playerSpeed * Time.deltaTime * mult;

        Vector2 offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * (generalConfig.tubeRadius + generalConfig.playerRadius);
        playerShell.position = Vector2.zero + offset;
    }
    
    private void Update()
    {
        float radius = Root.ConfigManager.GeneralConfig.playerRadius;
        playerShell.localScale = Vector3.one * radius * 2;
        
        //Make bottom of the view always look at center
        transform.up = playerShell.position - Vector3.zero;
    }
    
    
}
