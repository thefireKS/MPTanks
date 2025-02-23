using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomCode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roomCodeText;
    private void OnEnable()
    {
        roomCodeText.text = "Room Code: " + PhotonNetwork.CurrentRoom.Name;
    }

    public void CopyRoomCode()
    {
        GUIUtility.systemCopyBuffer = PhotonNetwork.CurrentRoom.Name;
    }
}
