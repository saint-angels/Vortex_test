using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public event Action OnPlayPressed = () => { };
    
    [SerializeField] private RectTransform hudContainer = null;
    [SerializeField] private Button playButton = null;
    [SerializeField] private GameObject menu;

    private AnimationConfig animationCfg;

    private void Awake()
    {
        playButton.onClick.AddListener(() => OnPlayPressed());
    }

    public void Init()
    {
        animationCfg = Root.ConfigManager.Animation;
    }

    public void SetMenuVisible(bool isVisible)
    {
        menu.SetActive(isVisible);
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
