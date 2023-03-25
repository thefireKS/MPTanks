using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    public static SpawnPlayers Instance;
    
    [SerializeField] private GameObject player;
    [Space(5)]
    [SerializeField] private float spawnRadius;

    private GameObject _myPlayer;

    private void Start()
    {
        Instance = this;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        var spawnPos = Random.insideUnitCircle * spawnRadius;
        _myPlayer = PhotonNetwork.Instantiate(player.name, spawnPos, quaternion.identity);
    }
    
    public void TeleportPlayer(GameObject player)
    {
        var newPosition = Random.insideUnitCircle * spawnRadius;
        player.transform.position = newPosition;
    }

    
}
