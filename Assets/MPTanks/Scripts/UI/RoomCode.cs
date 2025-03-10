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
#if UNITY_WEBGL
        WebGLCopyAndPaste.WebGLCopyAndPasteAPI.CopyToClipboard(PhotonNetwork.CurrentRoom.Name);
#endif
#if UNITY_DESKTOP
        GUIUtility.systemCopyBuffer = PhotonNetwork.CurrentRoom.Name;
#endif
    }
}
