using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSegment : MonoBehaviour
{
    public float Length { get; private set; }

    private void Awake()
    {
        Length = GetComponentInChildren<MeshFilter>().mesh.bounds.extents.z;
    }

    public void Init()
    {
        
    }
}
