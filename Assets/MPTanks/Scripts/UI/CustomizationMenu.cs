using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    private static readonly int InputColor = Shader.PropertyToID("_InputColor");

    [Header("Main Tank Visualisation")] 
    [SerializeField] private Image tankTower;
    [SerializeField] private Image tankBase;
    [SerializeField] private Image tankWheels;
    [SerializeField] private Image tankAmmo;
    [Space(10), Header("RGB sliders")] 
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [Space(10), Header("Extra settings")] 
    [SerializeField] private int extraWheelsScale;
    [SerializeField] private Material colorMaterial;

    private float _r, _g, _b;
    private Color _setColor;
    
    private void OnEnable()
    {
        _r = CurrentCustomPlayerPropertiesHandler.instance.red;
        _g = CurrentCustomPlayerPropertiesHandler.instance.green;
        _b = CurrentCustomPlayerPropertiesHandler.instance.blue;
        
        _setColor = new Color(_r,_g,_b);
        
        colorMaterial.SetColor(InputColor,_setColor);

        redSlider.value = _r;
        greenSlider.value = _g;
        blueSlider.value = _b;
        
        tankTower.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankTower
            [CurrentCustomPlayerPropertiesHandler.instance.tankTower];
        tankBase.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankBase
            [CurrentCustomPlayerPropertiesHandler.instance.tankBase];
        tankWheels.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankWheels
            [CurrentCustomPlayerPropertiesHandler.instance.tankWheels];
        tankAmmo.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankAmmo
            [CurrentCustomPlayerPropertiesHandler.instance.tankAmmo];
        
        tankWheels.SetNativeSize();
        tankWheels.rectTransform.sizeDelta = new Vector2(tankWheels.rectTransform.sizeDelta.x * extraWheelsScale,
            tankWheels.rectTransform.sizeDelta.y * extraWheelsScale);
    }

    public void SaveParameters()
    {
        CurrentCustomPlayerPropertiesHandler.instance.UpdateHashtableProperties();
    }
    
    public void SetActiveCategory(GameObject category)
    {
        category.SetActive(!category.activeSelf);
    }

    public void ApplyWheelsChanges(int id)
    {
        tankWheels.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankWheels[id];
        CurrentCustomPlayerPropertiesHandler.instance.tankWheels = id;
        
        tankWheels.SetNativeSize();
        tankWheels.rectTransform.sizeDelta = new Vector2(tankWheels.rectTransform.sizeDelta.x * extraWheelsScale,
            tankWheels.rectTransform.sizeDelta.y * extraWheelsScale);

        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["TankWheels"] = id;
        PlayerPrefs.SetInt("TankWheels",id);
    }

    public void ApplyBaseChanges(int id)
    {
        tankBase.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankBase[id];
        CurrentCustomPlayerPropertiesHandler.instance.tankBase = id;
        
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["TankBase"] = id;
        PlayerPrefs.SetInt("TankBase",id);
    }

    public void ApplyTowerChanges(int id)
    {
        tankTower.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankTower[id];
        CurrentCustomPlayerPropertiesHandler.instance.tankTower = id;
        
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["TankTower"] = id;
        PlayerPrefs.SetInt("TankTower",id);
    }

    public void ApplyAmmoChanges(int id)
    {
        tankAmmo.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankAmmo[id];
        CurrentCustomPlayerPropertiesHandler.instance.tankAmmo = id;
        
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["TankAmmo"] = id;
        PlayerPrefs.SetInt("TankAmmo",id);
    }
    
    public void ApplyRedColorChanges(Single value)
    {
        _r = value;
        _setColor.r = _r;
        CurrentCustomPlayerPropertiesHandler.instance.red = _r;
        
        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Red"] = value;
        colorMaterial.SetColor(InputColor,_setColor);
        PlayerPrefs.SetFloat("Red",value);
    }    
    
    public void ApplyGreenColorChanges(Single value)
    {
        _g = value;
        _setColor.g = _g;
        CurrentCustomPlayerPropertiesHandler.instance.green = _g;

        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Green"] = value;
        colorMaterial.SetColor(InputColor,_setColor);
        PlayerPrefs.SetFloat("Green",value);
    }
    
    public void ApplyBlueColorChanges(Single value)
    {
        _b = value;
        _setColor.b = _b;
        CurrentCustomPlayerPropertiesHandler.instance.blue = _b;

        CurrentCustomPlayerPropertiesHandler.instance.PlayerCustomPropertiesHashtable["Blue"] = value;
        colorMaterial.SetColor(InputColor,_setColor);
        PlayerPrefs.SetFloat("Blue",value);
    }
    
}