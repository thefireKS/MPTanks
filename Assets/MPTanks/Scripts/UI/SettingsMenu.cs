using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInputField;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Nickname"))
            nicknameInputField.text = PlayerPrefs.GetString("Nickname");
    }
    
    public void ChangeName(string value)
    {
        PhotonNetwork.NickName = value;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Nickname"] = value;
        
        PlayerPrefs.SetString("Nickname",value);
    }
    
    public void ChangeName(TMP_InputField inputField)
    {
        PhotonNetwork.NickName = inputField.text;
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Nickname"] = inputField.text;
        
        PlayerPrefs.SetString("Nickname",inputField.text);
    }

}
