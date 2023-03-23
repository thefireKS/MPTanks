using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField] private byte maxPlayersPerRoom = 5;

    [SerializeField] private GameObject controllPanel;
    
    private void Awake()
    {
        if(!PhotonNetwork.IsConnected) PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true; // необходимо для того, чтобы быть уверенным в том, что комнаты игроков будут синхронизованы с master-клиентом
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master!");
        controllPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = maxPlayersPerRoom});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined to room!");
        PhotonNetwork.LoadLevel(1);
    }
    
    
}