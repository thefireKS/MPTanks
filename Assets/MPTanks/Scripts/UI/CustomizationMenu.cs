using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    [Header("Main Tank Visualisation")] 
    [SerializeField]
    private Image tankTower;
    [SerializeField]
    private Image tankBase;
    [SerializeField]
    private Image tankWheels;
    
    private void OnEnable()
    {
        var setColor = new Color(CurrentCustomPlayerPropertiesHandler.instance.red,
            CurrentCustomPlayerPropertiesHandler.instance.green, 
            CurrentCustomPlayerPropertiesHandler.instance.blue);
        
        tankTower.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankTower
            [CurrentCustomPlayerPropertiesHandler.instance.tankTower];
        tankBase.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankBase
            [CurrentCustomPlayerPropertiesHandler.instance.tankBase];
        tankWheels.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankWheels
            [CurrentCustomPlayerPropertiesHandler.instance.tankWheels];

        tankTower.color = setColor;
        tankBase.color = setColor;
        tankWheels.color = setColor;
    }
}
