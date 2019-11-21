using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSegment : MonoBehaviour
{
    [SerializeField] private Transform obstacleHolder;
    public float Length { get; private set; }

    private void Awake()
    {
        Length = GetComponentInChildren<MeshFilter>().mesh.bounds.size.z;
    }

    public void Init(GameObject obstaclePrefab)
    {
        foreach (Transform obstacle in obstacleHolder)
        {
            Destroy(obstacle.gameObject);
        }

        if (obstaclePrefab != null)
        {
            Instantiate(obstaclePrefab, obstacleHolder);
        }

    }
}
