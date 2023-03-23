using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [Space(5)]
    [SerializeField] private float spawnRadius;

    private void Start()
    {
        var spawnPos = Random.insideUnitCircle * spawnRadius;
        PhotonNetwork.Instantiate(player.name, spawnPos, quaternion.identity);
    }
}
