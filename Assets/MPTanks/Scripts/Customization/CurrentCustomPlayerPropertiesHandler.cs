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

        UpdateHashtableProperties();
    }

    public void SetPlayerPropertiesFromPrefs()
    {
        red = PlayerPrefs.GetFloat("Red");
        green = PlayerPrefs.GetFloat("Green");
        blue = PlayerPrefs.GetFloat("Blue");

        tankWheels = PlayerPrefs.GetInt("TankWheels");
        tankBase = PlayerPrefs.GetInt("TankBase");
        tankTower = PlayerPrefs.GetInt("TankTower");

        tankAmmo = PlayerPrefs.GetInt("TankAmmo");
        
        UpdateHashtableProperties();
    }

    private void UpdateHashtableProperties()
    {
        PlayerCustomPropertiesHashtable["Red"] = red;
        PlayerCustomPropertiesHashtable["Green"] = green;
        PlayerCustomPropertiesHashtable["Blue"] = blue;

        PlayerPrefs.SetFloat("Red",red);
        PlayerPrefs.SetFloat("Green",green);
        PlayerPrefs.SetFloat("Blue",blue);
        
        PlayerCustomPropertiesHashtable["TankWheels"] = tankWheels;
        PlayerCustomPropertiesHashtable["TankBase"] = tankBase;
        PlayerCustomPropertiesHashtable["TankTower"] = tankTower;

        PlayerCustomPropertiesHashtable["TankAmmo"] = tankAmmo;
        
        PlayerPrefs.SetInt("TankWheels",tankWheels);
        PlayerPrefs.SetInt("TankBase",tankBase);
        PlayerPrefs.SetInt("TankTower",tankTower);
        PlayerPrefs.SetInt("TankAmmo",tankAmmo);
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
