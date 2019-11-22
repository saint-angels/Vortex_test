using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class PipeSegment : MonoBehaviour
{
    public bool HasObstacles => obstacleRenderer != null;
    
    public bool ObstaclesVisible { get; private set; }
    public float Length { get; private set; }

    public int StartRotationZ { get; private set; }
    public int EndRotationZ { get; private set; }
    
    [SerializeField] private int[] allowedStartRotations;
    [SerializeField] private Transform obstacleHolder;
    [SerializeField] private Renderer obstacleRenderer;
    private static readonly int TintColor = Shader.PropertyToID("_TintColor");

    private AnimationConfig animationConfig;


    private void Awake()
    {
        Length = GetComponentInChildren<MeshFilter>().mesh.bounds.size.z;
        animationConfig = Root.ConfigManager.Animation;
    }

    public void ShowObstacles()
    {
        SetObstacleVisibility(1);
    }
    
    
    public void Init()
    {
        if (allowedStartRotations.Length > 1)
        {
            StartRotationZ = allowedStartRotations[UnityEngine.Random.Range(0, allowedStartRotations.Length)];
            EndRotationZ = allowedStartRotations[UnityEngine.Random.Range(0, allowedStartRotations.Length)];
        }
        
        SetObstacleVisibility(0);
    }

    private void SetObstacleVisibility(float alpha)
    {
        ObstaclesVisible = Mathf.Approximately(alpha, 0) == false;
        
        if (obstacleRenderer != null)
        {
            Color color = obstacleRenderer.material.GetColor(TintColor);
            color.a = alpha;
            obstacleRenderer.material.DOKill(true);
            
            //Show with ease, hide instantly
            if (ObstaclesVisible)
            {
                obstacleRenderer.material.DOColor(color, TintColor, animationConfig.obstacleAppearenceDuration).SetEase(animationConfig.obstacleAppearenceEase);    
            }
            else
            {
                obstacleRenderer.material.SetColor(TintColor, color);
            }
            
        }
    }
}
