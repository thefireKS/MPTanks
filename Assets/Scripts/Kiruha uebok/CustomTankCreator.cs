using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomTankCreator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer tankBase;
    [SerializeField] private Animator tankBaseAnimator;

    [SerializeField] private AnimatorOverrideController[] tankBases;
    [SerializeField] private SpriteRenderer[] tankTowers;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        
        var randomColor = new Color(Random.Range(0.2f,1f),Random.Range(0.2f,1f),Random.Range(0.2f,1f));
        
        tankBaseAnimator.runtimeAnimatorController = tankBases[Random.Range(0, tankBases.Length)];
        tankBase.color = randomColor;

        var randomTower = tankTowers[Random.Range(0, tankTowers.Length)];
        var instRandomTower = Instantiate(randomTower,transform.position, quaternion.identity, gameObject.transform);
        instRandomTower.color = randomColor;

        Destroy(this);
    }
}
