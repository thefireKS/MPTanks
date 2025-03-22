using System;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField createField;
    [SerializeField] private Toggle lockedLobbyToggle;

    private const string MAP_TAG = "Map";
    private int currentSelectedMap = 0;
    
    public void CreateRoom()
    {
        MainMenu.FixConnection();
        
        if (createField.text == null) return;
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.CustomRoomProperties = new Hashtable { { MAP_TAG, currentSelectedMap }};

        string[] lobbyProps = new[] { MAP_TAG};
        roomOptions.CustomRoomPropertiesForLobby = lobbyProps;

        roomOptions.IsOpen = !lockedLobbyToggle.isOn;
        roomOptions.IsVisible = true;
        roomOptions.BroadcastPropsChangeToAll = true;
        roomOptions.MaxPlayers = 8;
        PhotonNetwork.CreateRoom(createField.text, roomOptions);
    }

    public void SelectMap(int id)
    {
        currentSelectedMap = id;
    }
}
