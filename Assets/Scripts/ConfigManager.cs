﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public AnimationConfig Animation => animationConfig;
    public CameraConfig CameraConfig => cameraConfig;
    public GeneralConfig GeneralConfig => generalConfig;

    [SerializeField] private GeneralConfig generalConfig = null;
    [SerializeField] private AnimationConfig animationConfig = null;
    [SerializeField] private CameraConfig cameraConfig = null;
}
