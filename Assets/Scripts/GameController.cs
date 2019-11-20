using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum GameState
    {
        MAIN_MENU,
        PLAYING
    }
    
    [SerializeField] private Transform tubeTransform;

    private GeneralConfig generalConfig;

    private GameState currentState;

    public void Init(Player player)
    {
        player.OnDeath += OnPlayerOnDeath;
        player.Input.OnDirectionPressed += DirectionPressed;

        generalConfig = Root.ConfigManager.GeneralConfig;
        
        
    }

    private void SetState(GameState newState)
    {
        switch (newState)
        {
            case GameState.MAIN_MENU:
                break;
            case GameState.PLAYING:
                break;
        }
    }

    public void Reset()
    {
        
    }

    private void OnPlayerOnDeath()
    {
        print("Player died!");
        SetState(GameState.MAIN_MENU);
    }

    private void DirectionPressed(PlayerInput.Direction direction)
    {
        float mult = 0;
        switch (direction)
        {
            case PlayerInput.Direction.LEFT:
                mult = 1;
                break;
            case PlayerInput.Direction.RIGHT:
                mult = -1;
                break;
        }

        float rotation = generalConfig.tubeRotationSpeed * Time.deltaTime * mult;
        tubeTransform.Rotate(Vector3.forward, rotation);
    }
}
