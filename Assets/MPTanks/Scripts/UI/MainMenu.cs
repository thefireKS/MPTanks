using System.Linq;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField joinField;
    
    private const string MAP_TAG = "Map";
    const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public void JoinRoom()
    {
        FixConnection();
        
        if(joinField.text == null) return;
        
        PhotonNetwork.JoinRoom(joinField.text);
    }
    
    public void QuickMatch()
    {
        FixConnection();
        
        string randomRoomcode = RandomString(8);
        int randomMap = Random.Range(0,3);
        Debug.Log($"Map is gonna be {randomMap}");
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.CustomRoomProperties = new Hashtable { { MAP_TAG, randomMap }};

        string[] lobbyProps = new[] { MAP_TAG};
        roomOptions.CustomRoomPropertiesForLobby = lobbyProps;
        
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.BroadcastPropsChangeToAll = true;
        roomOptions.MaxPlayers = 8;
        
        PhotonNetwork.JoinRandomOrCreateRoom(null,0,MatchmakingMode.FillRoom,
            null, null,randomRoomcode,roomOptions);
    }
    
    private static string RandomString(int length)
    {
        var result = "";
        for(int i=0; i<length; i++)
        {
            result += chars[Random.Range(0, chars.Length)];
        }

        return result;
    }

    public static void FixConnection()
    {
        if (!PhotonNetwork.IsConnected)    
        {    
            print("Connecting to server..");    
            PhotonNetwork.ConnectUsingSettings();    
        }
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}