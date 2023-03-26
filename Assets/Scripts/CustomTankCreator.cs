using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class CustomTankCreator : MonoBehaviourPunCallbacks, IPunObservable
{
    [Header("Visuals")]
    [SerializeField] private TMP_Text nickname;
    [Space(5)]
    [SerializeField] private SpriteRenderer tankBase;
    [SerializeField] private SpriteRenderer tankTower;
    [Space(10)]
    [Header("Random")]
    [SerializeField] private AnimatorOverrideController[] tankBases;
    [SerializeField] private Sprite[] tankTowers;
    public Player Player { get; private set; }

    private float r, g, b;
    private PhotonView view;
    private Animator tankBaseAnimator;

    private string randomBase, randomTower;

    private Hashtable _customProperties = new Hashtable
    {
        {"R", (float)1f},
        {"G", (float)1f},
        {"B", (float)1f},
        {"tankBase", (string)"Base1"},
        {"tankTower", (string)"gun1"},
        {"nickname", (string)"Player"}
    };

    public override void OnEnable()
    {
        view = GetComponent<PhotonView>();
        tankBaseAnimator = GetComponent<Animator>();
        
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

        _customProperties["R"] = r;
        _customProperties["G"] = g;
        _customProperties["B"] = b;

        _customProperties["tankBase"] = randomBase;
        _customProperties["tankTower"] = randomTower;

        _customProperties["nickname"] = PhotonNetwork.NickName;
        
        if(!view.IsMine) return;
        PhotonNetwork.SetPlayerCustomProperties(_customProperties);
        //view.RPC("SetTexturesAndColor", RpcTarget.All, r, g, b, randomBase, randomTower);
    }
    
     private void SetPlayerInfo(Player player)
    {
        Player = player;
        SetTextures(player);
    }

    public override void OnPlayerPropertiesUpdate(Player target, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(target,changedProps);
        if (target != null || target == Player)
        {
            if(changedProps.ContainsKey("R") && changedProps.ContainsKey("G") && changedProps.ContainsKey("B")
               && changedProps.ContainsKey("tankBase") && changedProps.ContainsKey("tankTower"))
                SetTextures(target);
        }
    }
    
    private void SetTextures(Player player)
    {
        float r = 0;
        float g = 0;
        float b = 0;
        string _tankBase = null;
        string _tankTower = null;

        if (player.CustomProperties.ContainsKey("R"))
            r = (float) player.CustomProperties["R"];
        if (player.CustomProperties.ContainsKey("G"))
            g = (float) player.CustomProperties["G"];
        if (player.CustomProperties.ContainsKey("B"))
            b = (float) player.CustomProperties["B"];
        
        if (player.CustomProperties.ContainsKey("tankBase"))
            _tankBase = (string) player.CustomProperties["tankBase"];
        if (player.CustomProperties.ContainsKey("tankTower"))
            _tankTower = (string) player.CustomProperties["tankTower"];

        if (player.CustomProperties.ContainsKey("nickname"))
            nickname.text = (string) player.CustomProperties["nickname"];
        
        var randColor = new Color(r, g, b);
        tankBase.color = randColor;
        tankBaseAnimator.runtimeAnimatorController = Array.Find(tankBases, s => s.name == _tankBase);
        
        tankTower.color = randColor;
        tankTower.sprite = Array.Find(tankTowers, s => s.name == _tankTower);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        info.Sender.TagObject = gameObject;
        SetPlayerInfo(info.Sender);
    }
}