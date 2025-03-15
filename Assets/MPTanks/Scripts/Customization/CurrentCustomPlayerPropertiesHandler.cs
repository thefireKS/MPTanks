using System;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine;
using Random = UnityEngine.Random;

public class CurrentCustomPlayerPropertiesHandler : MonoBehaviour
{
    public PlayerCustomProperties playerProperties;
    public static CurrentCustomPlayerPropertiesHandler instance;

    public float red, green, blue;
    public int tankTower, tankBase, tankWheels, tankAmmo;

    public void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerRandomProperties()
    {
        var r = Random.Range(0.2f, 1f);
        red = r;
        var g = Random.Range(0.2f, 1f);
        green = g;
        var b = Random.Range(0.2f, 1f);
        blue = b;
        
        var randomWheels = Random.Range(0, playerProperties.tankWheels.Length);
        tankWheels = randomWheels;
        var randomBase = Random.Range(0, playerProperties.tankBase.Length);
        tankBase = randomBase;
        var randomTower = Random.Range(0, playerProperties.tankTower.Length);
        tankTower = randomTower;
        
        var randomAmmo = Random.Range(0, playerProperties.tankAmmo.Length);
        tankAmmo = randomAmmo;
        
        PlayerCustomPropertiesHashtable["Red"] = r;
        PlayerCustomPropertiesHashtable["Green"] = g;
        PlayerCustomPropertiesHashtable["Blue"] = b;

        PlayerCustomPropertiesHashtable["TankWheels"] = randomWheels;
        PlayerCustomPropertiesHashtable["TankBase"] = randomBase;
        PlayerCustomPropertiesHashtable["TankTower"] = randomTower;

        PlayerCustomPropertiesHashtable["TankAmmo"] = randomAmmo;
    }
    
    public readonly Hashtable PlayerCustomPropertiesHashtable = new()
    {
        {"Red", (float)1f},
        {"Green", (float)1f},
        {"Blue", (float)1f},
        {"TankWheels", 0},
        {"TankBase", 0},
        {"TankTower", 0},
        {"TankAmmo", 0},
        {"Nickname", (string) "Player"}
    };
}
