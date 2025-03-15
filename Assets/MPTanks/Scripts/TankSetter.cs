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
        if (target == null && null != Player) return;
            SetTextures(target);
    }
    
    private void SetTextures(Player player)
    {
        Debug.Log($"Setting {player.NickName}'s textures");
        
        float r = 0;
        float g = 0;
        float b = 0;

        if (player.CustomProperties.ContainsKey("Red"))
            r = (float) player.CustomProperties["Red"];
        if (player.CustomProperties.ContainsKey("Green"))
            g = (float) player.CustomProperties["Green"];
        if (player.CustomProperties.ContainsKey("Blue"))
            b = (float) player.CustomProperties["Blue"];

        if (player.CustomProperties.ContainsKey("TankWheels"))
        {
            var wheels = (int) player.CustomProperties["TankWheels"];
            tankWheels.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankWheels[wheels];
        }
        
        if (player.CustomProperties.ContainsKey("TankBase"))
        {
            var tbase = (int) player.CustomProperties["TankBase"];
            tankBase.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankBase[tbase];
        }
        
        if (player.CustomProperties.ContainsKey("TankTower"))
        {
            var tower = (int)player.CustomProperties["TankTower"];
            tankTower.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankTower[tower];
        }

        if (player.CustomProperties.ContainsKey("Nickname"))
            nickname.text = (string) player.CustomProperties["Nickname"];
        
        var propColor = new Color(r, g, b);
        
        tankWheels.color = propColor;
        tankBase.color = propColor;
        tankTower.color = propColor;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        info.Sender.TagObject = gameObject;
        SetPlayerInfo(info.Sender);
    }
}