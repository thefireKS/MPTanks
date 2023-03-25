using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class TankSetter : CustomTankCreator, IPunObservable
{
    [SerializeField] private TMP_Text nickname;
    
    private Color colorOption;
    public Player Player { get; private set; }

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