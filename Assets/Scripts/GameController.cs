using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public event Action<float> OnScoreUpdated = (score) => { }; 
    
    enum GameState
    {
        MAIN_MENU,
        PLAYING
    }

    private GeneralConfig generalConfig;

    private GameState currentState;

    private float Score
    {
        set
        {
            score = value;
            OnScoreUpdated(score);
        }
        get => score;
    }

    private float score;

    public void Init(Player player)
    {
        Root.Player.Input.OnDirectionPressed += KeyboardDirectionPressed;
        player.OnDeath += OnPlayerOnDeath;

        generalConfig = Root.ConfigManager.GeneralConfig;
        Root.UIManager.OnPlayPressed += OnPlayPressed;
        SetState(GameState.PLAYING);
        
        
    }

    private void KeyboardDirectionPressed(PlayerInput.Direction obj)
    {
        if (currentState == GameState.PLAYING)
        {
            Root.UIManager.SetButtonHelpersVisible(false);
        }
    }

    private void OnPlayPressed()
    {
        SetState(GameState.PLAYING);
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.MAIN_MENU:
                break;
            case GameState.PLAYING:
                Score += Root.ConfigManager.PipeGeneratorConfig.pipeMoveSpeed * Time.deltaTime;
                break;
        }
    }

    private void SetState(GameState newState)
    {
        Score = 0;
        switch (newState)
        {
            case GameState.MAIN_MENU:
                Root.PipeController.SetActive(false);
                Root.UIManager.SetMenuVisible(true);
                break;
            case GameState.PLAYING:
                Root.PipeController.SetActive(true);
                Root.UIManager.SetMenuVisible(false);
                Root.Player.PrepareForRun();
                break;
        }

        currentState = newState;
    }

    public void Reset()
    {
        
    }

    private void OnPlayerOnDeath()
    {
        Root.CameraController.StartCameraShake(.5f);
        SetState(GameState.MAIN_MENU);
    }
}
