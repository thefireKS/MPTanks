using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomTankCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] protected SpriteRenderer tankWheels;
    [SerializeField] protected SpriteRenderer tankBase;
    [SerializeField] protected SpriteRenderer tankTower;

    [SerializeField] protected Material colorOverrideMaterial;

    private PhotonView view;
    

    public override void OnEnable()
    {
        view = GetComponent<PhotonView>();
        
        PhotonNetwork.AddCallbackTarget(this);
        
        if(!view.IsMine) return;
        InitializeTexturesAndColor();
    }

    private void InitializeTexturesAndColor()
    {
        PhotonNetwork.SetPlayerCustomProperties(CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable);
        //view.RPC("SetTexturesAndColor", RpcTarget.All, r, g, b, randomBase, randomTower);
    }
}