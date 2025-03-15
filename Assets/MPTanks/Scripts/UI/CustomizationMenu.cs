using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    private static readonly int InputColor = Shader.PropertyToID("_InputColor");

    [Header("Main Tank Visualisation")] 
    [SerializeField]
    private Image tankTower;
    [SerializeField]
    private Image tankBase;
    [SerializeField]
    private Image tankWheels;
    [Space(10), Header("Extra settings")] 
    [SerializeField] private int extraWheelsScale;
    
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

        tankTower.material.SetColor(InputColor,setColor);
        tankBase.material.SetColor(InputColor,setColor);
        tankWheels.material.SetColor(InputColor,setColor);
        
        tankWheels.SetNativeSize();
        tankWheels.rectTransform.sizeDelta = new Vector2(tankWheels.rectTransform.sizeDelta.x * 3,tankWheels.rectTransform.sizeDelta.y * 3);
    }
}
