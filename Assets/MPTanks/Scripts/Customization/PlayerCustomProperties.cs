using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCustomProperties",menuName = "Player/Custom Properties")]
public class PlayerCustomProperties : ScriptableObject
{
    [Header("Tank Body")]
    public Sprite[] tankWheels;
    public Sprite[] tankBase;
    public Sprite[] tankTower;
    [Header("Tank Ammo"),Space(10)]
    public Sprite[] tankAmmo;
}
