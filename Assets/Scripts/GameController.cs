using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform tubeTransform;

    public void Init()
    {
            
    }

    private void Update()
    {
        float radius = Root.ConfigManager.GeneralConfig.tubeRadius;
        tubeTransform.localScale = 2 * radius * Vector3.one;
    }
}
