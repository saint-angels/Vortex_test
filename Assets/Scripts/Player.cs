using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnDeath = () => { };
    
    public PlayerInput Input { get; private set; }

    [SerializeField] private Transform playerShell;
    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private Collider collider;

    private GeneralConfig generalConfig;

    public void Init()
    {
        generalConfig = Root.ConfigManager.GeneralConfig;
        Input =  GetComponent<PlayerInput>();
    }

    public void PrepareForRun()
    {
        deathParticles.Stop(true);
        deathParticles.Clear();
        playerRenderer.enabled = true;
        collider.enabled = true;
    }

        
    private void Update()
    {
        float radius = Root.ConfigManager.GeneralConfig.playerRadius;
        playerShell.localScale = Vector3.one * radius * 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        deathParticles.Play(true);
        playerRenderer.enabled = false;
        collider.enabled = false;
        OnDeath();
    }
}
