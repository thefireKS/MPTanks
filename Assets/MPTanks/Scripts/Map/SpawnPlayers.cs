using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    public static SpawnPlayers Instance;
    
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> mapPool;

    private MapData _currentMapData;

    private void Start()
    {
        Instance = this;

        SetMap();
        SpawnPlayer();
    }

    private void SpawnPlayer()
    { 
        PhotonNetwork.Instantiate(player.name, _currentMapData.GetAvailablePosition(), quaternion.identity);
    }

    private void SetMap()
    {
        var id = (int)PhotonNetwork.CurrentRoom.CustomProperties["Map"];
        
        
        _currentMapData = mapPool[id].GetComponent<MapData>();
        _currentMapData.gameObject.SetActive(true);
        
        foreach (var map in mapPool)
        {
            if(!map.activeSelf)
                Destroy(map.gameObject);
        }
    }
    
    public void TeleportPlayer(GameObject player)
    {
        player.transform.position = _currentMapData.GetAvailablePosition();
    }
}
