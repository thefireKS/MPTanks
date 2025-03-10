using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCustomProperties",menuName = "Player/Custom Properties")]
public class PlayerCustomProperties : ScriptableObject
{
    [Header("Tank Body")]
    public Texture[] tankWheels;
    public Texture[] tankBase;
    public Texture[] tankTower;
    [Header("Tank Ammo"),Space(10)]
    public Texture[] tankAmmo;
}
