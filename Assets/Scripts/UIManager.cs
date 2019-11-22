﻿using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Configs;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public event Action<PlayerInput.Direction> OnScreenDirectionPressed = (dir) => { };
    public event Action OnPlayPressed = () => { };
    
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private TMPro.TextMeshProUGUI scoreLabel;

    [Header("Screen controls")]
    [SerializeField] private CustomButton screenButtonLeft;
    [SerializeField] private CustomButton screenButtonRight;

    private AnimationConfig animationCfg;

    private void Awake()
    {
        playButton.onClick.AddListener(() => OnPlayPressed());

        screenButtonLeft.OnHeldDown += () => OnScreenDirectionPressed(PlayerInput.Direction.LEFT);
        screenButtonRight.OnHeldDown += () => OnScreenDirectionPressed(PlayerInput.Direction.RIGHT);
    }

    public void Init()
    {
        animationCfg = Root.ConfigManager.Animation;
        Root.GameController.OnScoreUpdated += OnScoreUpdated;
    }

    private void OnScoreUpdated(float score)
    {
        scoreLabel.text = $"{(int)score}";
    }

    public void SetMenuVisible(bool isVisible)
    {
        menuPanel.SetActive(isVisible);
        gameplayPanel.SetActive(isVisible == false);
    }
    

    private void LateUpdate()
    {
        //TODO: Process abrsact hud-objects with abstact anchors
        
//            Vector2 screenPoint = Root.CameraController.WorldToScreenPoint(userBodyHUDPoint.position);
//            Vector2 localPoint;
//            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(hudContainer, screenPoint, null, out localPoint))
//            {
//                userBodyHUD.localPosition = localPoint;
//            }
        
    }
}
