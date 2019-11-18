using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput Input { get; private set; }

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
        Input =  GetComponent<PlayerInput>();
    }

        
    private void Update()
    {
        float radius = Root.ConfigManager.GeneralConfig.playerRadius;
        playerShell.localScale = Vector3.one * radius * 2;
        
        //Make bottom of the view always look at center
//        transform.up = playerShell.position - Vector3.zero;
    }
    
    
}
