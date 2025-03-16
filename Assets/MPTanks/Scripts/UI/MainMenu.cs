using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField joinField;

    public void ChangeName(TMP_InputField nicknameField)
    {
        PhotonNetwork.NickName = nicknameField.text;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Nickname"] = nicknameField.text;
    }

    public void JoinRoom()
    {
        if(joinField.text == null) return;
        
        PhotonNetwork.JoinRoom(joinField.text);
    }
    
    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}