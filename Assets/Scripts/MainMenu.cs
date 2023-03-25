using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField nicknameField;
    [Space(5)]
    [SerializeField] private TMP_InputField createField;
    [SerializeField] private TMP_InputField joinField;

    public void ChangeName()
    {
        PhotonNetwork.NickName = nicknameField.text;
    }

    public void CreateRoom()
    {
        if (createField.text == null) return;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.BroadcastPropsChangeToAll = true;
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.CreateRoom(createField.text, roomOptions);
    }

    public void JoinRoom()
    {
        if(joinField.text == null) return;
        
        PhotonNetwork.JoinRoom(joinField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}