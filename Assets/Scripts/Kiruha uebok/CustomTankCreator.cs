using System;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomTankCreator : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer tankBase;
    [SerializeField] protected SpriteRenderer tankTower;
    
    [SerializeField] protected Animator tankBaseAnimator;

    [SerializeField] protected AnimatorOverrideController[] tankBases;
    [SerializeField] protected Sprite[] tankTowers;

    private float r, g, b;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        
        InitializeTexturesAndColor();
    }

    private void InitializeTexturesAndColor()
    {
        r = Random.Range(0.2f, 1f);
        g = Random.Range(0.2f, 1f);
        b = Random.Range(0.2f, 1f);

        var randomBase = tankBases[Random.Range(0, tankBases.Length)].name;
        var randomTower = tankTowers[Random.Range(0, tankTowers.Length)].name;
        
        view.RPC("SetTexturesAndColor",RpcTarget.All, r,g,b,randomBase,randomTower);
    }

    [PunRPC]
    private void SetTexturesAndColor(float r,float g, float b, string animator, string sprite)
    {
        var randColor = new Color(r,g,b);
        tankBase.color = randColor;
        tankBaseAnimator.runtimeAnimatorController = Array.Find(tankBases, s => s.name == animator);

        tankTower.color = randColor;
        tankTower.sprite = Array.Find(tankTowers, s => s.name == sprite);
    }
}
