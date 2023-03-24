using System;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class TankSetter : CustomTankCreator, IPunObservable
{
    private Color colorOption;

    private Player player;

    private void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;

        colorOption = new Color((float) instantiationData[0], (float) instantiationData[1],
            (float) instantiationData[2]);
        string baseOption = (string) instantiationData[3];
        string towerOption = (string) instantiationData[4];

        tankBase.color = colorOption;
        tankBaseAnimator.runtimeAnimatorController = Array.Find(tankBases, s => s.name == baseOption);

        tankTower.color = colorOption;
        tankTower.sprite = Array.Find(tankTowers, s => s.name == towerOption);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(tankBase.color.r);
            stream.SendNext(tankBase.color.g);
            stream.SendNext(tankBase.color.b);
            stream.SendNext(tankBaseAnimator.runtimeAnimatorController.name);
            stream.SendNext(tankTower.sprite.name);
        }
        else
        {
            colorOption = new Color((float) stream.ReceiveNext(), (float) stream.ReceiveNext(),
                (float) stream.ReceiveNext());
            tankBase.color = colorOption;
            tankTower.color = colorOption;

            string baseName = (string) stream.ReceiveNext();
            tankBaseAnimator.runtimeAnimatorController = Array.Find(tankBases, s => s.name == baseName);

            string towerName = (string) stream.ReceiveNext();
            tankTower.sprite = Array.Find(tankTowers, s => s.name == towerName);
        }
    }
}