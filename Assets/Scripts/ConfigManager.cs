using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public AnimationConfig Animation => animationConfig;
    public CameraConfig CameraConfig => cameraConfig;
    public GeneralConfig GeneralConfig => generalConfig;

    public PipeGeneratorConfig PipeGeneratorConfig => pipeGeneratorConfig;

    [SerializeField] private GeneralConfig generalConfig = null;
    [SerializeField] private AnimationConfig animationConfig = null;
    [SerializeField] private CameraConfig cameraConfig = null;
    [SerializeField] private PipeGeneratorConfig pipeGeneratorConfig = null;
}
