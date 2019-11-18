using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeGeneratorConfig", menuName = "Config/PipeGeneratorConfig")]
public class PipeGeneratorConfig : ScriptableObject
{
    public int maxAlivePipes = 2;
    public float pipeMoveSpeed = 1f;
}
