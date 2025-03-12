using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomTankCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] protected SpriteRenderer tankBase;
    [SerializeField] protected SpriteRenderer tankTower;
    [SerializeField] protected Animator tankBaseAnimator;
    [SerializeField] protected AnimatorOverrideController[] tankBases;
    [SerializeField] protected Sprite[] tankTowers;

    private float r, g, b;
    protected PhotonView view;

    private string randomBase, randomTower;

    public override void OnEnable()
    {
        view = GetComponent<PhotonView>();
        
        PhotonNetwork.AddCallbackTarget(this);
        
        if(!view.IsMine) return;
        InitializeTexturesAndColor();
    }

    private void InitializeTexturesAndColor()
    {
        r = Random.Range(0.2f, 1f);
        g = Random.Range(0.2f, 1f);
        b = Random.Range(0.2f, 1f);

        randomBase = tankBases[Random.Range(0, tankBases.Length)].name;
        randomTower = tankTowers[Random.Range(0, tankTowers.Length)].name;

        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["R"] = r;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["G"] = g;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["B"] = b;

        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["tankBase"] = randomBase;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["tankTower"] = randomTower;

        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["nickname"] = PhotonNetwork.NickName;
        
        if(!view.IsMine) return;
        PhotonNetwork.SetPlayerCustomProperties(CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable);
        //view.RPC("SetTexturesAndColor", RpcTarget.All, r, g, b, randomBase, randomTower);
    }
}