using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ConfigManager configManager = null;
    [SerializeField] private CameraController cameraController = null;
    [SerializeField] private UIManager uiManager = null;
    [SerializeField] private Player player = null;
    [SerializeField] private GameController gameController = null;
    [SerializeField] private PipeGenerator pipeGenerator = null;
    
    private static Root _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        cameraController.Init();
        uiManager.Init();

        player.Init();
        GameController.Init(player.Input);
        pipeGenerator.Init();
    }

    public static GameController GameController => _instance.gameController;
    public static ConfigManager ConfigManager => _instance.configManager;
    public static CameraController CameraController => _instance.cameraController;
    public static UIManager UIManager => _instance.uiManager;

    public static Player Player => _instance.player;
}
