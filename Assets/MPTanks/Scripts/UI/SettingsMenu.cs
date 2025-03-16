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
        if(PlayerPrefs.HasKey("Nickname"))
            nicknameInputField.text = CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Nickname"].ToString();
    }
}
