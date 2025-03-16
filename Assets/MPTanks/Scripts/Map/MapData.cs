using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class MapData : MonoBehaviour
{
    public Transform[] spawnPositions;

    public Vector3 GetAvailablePosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].position;
    }
}
