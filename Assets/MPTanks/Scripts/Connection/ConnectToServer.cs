using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject loadingWindow;
    [SerializeField] private GameObject firstTimeNicknameWindow;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        loadingWindow.SetActive(false);
        firstTimeNicknameWindow.SetActive(true);
        CurrentCustomPlayerPropertiesHandler.instance.SetPlayerRandomProperties();
    }
    
    public void ChangeName(TMP_InputField nicknameField)
    {
        PhotonNetwork.NickName = nicknameField.text;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Nickname"] = nicknameField.text;
    }
    
    public void ChangeNameAndConnect(TMP_InputField nicknameField)
    {
        PhotonNetwork.NickName = nicknameField.text;
        SceneManager.LoadScene("MainMenu");
    }
}
