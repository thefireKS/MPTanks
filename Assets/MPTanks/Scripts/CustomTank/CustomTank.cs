using Photon.Pun;
using TMPro;
using UnityEngine;

public class CustomTank : MonoBehaviour
{
    [SerializeField] private TMP_Text nickname;
    [Space(10)]
    [SerializeField] protected SpriteRenderer tankWheels;
    [SerializeField] protected SpriteRenderer tankBase;
    [SerializeField] protected SpriteRenderer tankTower;
    [Space(10)]
    [SerializeField] protected Material colorOverrideMaterial;
    
    private PhotonView _view;
    private static readonly int InputColor = Shader.PropertyToID("_InputColor");

    private void OnEnable()
    {
        _view = GetComponent<PhotonView>();
        
        var mat = new Material(colorOverrideMaterial);
        
        float r = 0;
        float g = 0;
        float b = 0;

        if (_view.Owner.CustomProperties.ContainsKey("Red"))
            r = (float) _view.Owner.CustomProperties["Red"];
        if (_view.Owner.CustomProperties.ContainsKey("Green"))
            g = (float) _view.Owner.CustomProperties["Green"];
        if (_view.Owner.CustomProperties.ContainsKey("Blue"))
            b = (float) _view.Owner.CustomProperties["Blue"];

        if (_view.Owner.CustomProperties.ContainsKey("TankWheels"))
        {
            var wheels = (int) _view.Owner.CustomProperties["TankWheels"];
            tankWheels.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankWheels[wheels];
        }
        
        if (_view.Owner.CustomProperties.ContainsKey("TankBase"))
        {
            var tbase = (int) _view.Owner.CustomProperties["TankBase"];
            tankBase.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankBase[tbase];
        }
        
        if (_view.Owner.CustomProperties.ContainsKey("TankTower"))
        {
            var tower = (int)_view.Owner.CustomProperties["TankTower"];
            tankTower.sprite = CurrentCustomPlayerPropertiesHandler.instance.playerProperties.tankTower[tower];
        }

        nickname.text = _view.Owner.NickName;
        
        var propColor = new Color(r, g, b);
        
        mat.SetColor(InputColor,propColor);
        
        tankWheels.material = mat;
        tankBase.material = mat;
        tankTower.material = mat;
    }
}
