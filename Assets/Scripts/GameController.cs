using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum GameState
    {
        MAIN_MENU,
        PLAYING
    }

    private GeneralConfig generalConfig;

    private GameState currentState;

    public void Init(Player player)
    {
        player.OnDeath += OnPlayerOnDeath;

        generalConfig = Root.ConfigManager.GeneralConfig;
        Root.UIManager.OnPlayPressed += OnPlayPressed;
        SetState(GameState.PLAYING);
    }

    private void OnPlayPressed()
    {
        SetState(GameState.PLAYING);
    }

    private void SetState(GameState newState)
    {
        switch (newState)
        {
            case GameState.MAIN_MENU:
                Root.PipeController.SetActive(false);
                Root.UIManager.SetMenuVisible(true);
                break;
            case GameState.PLAYING:
                Root.PipeController.SetActive(true);
                Root.UIManager.SetMenuVisible(false);
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
}
