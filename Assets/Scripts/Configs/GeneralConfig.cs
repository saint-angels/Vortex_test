using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralConfig", menuName = "Config/GeneralConfig")]
public class GeneralConfig : ScriptableObject
{
    public float tubeRadius = 1f;
    public float tubeRotationSpeed = 10f;
    
    public float playerRadius = .25f;
    public float playerSpeed = 10f;
    public float rollSpeed = 1f;
    public float rollMaxAngle = 50f;

}
