using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomTankCreator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer tankBase;
    [SerializeField] private SpriteRenderer tankTower;
    
    [SerializeField] private Animator tankBaseAnimator;

    [SerializeField] private AnimatorOverrideController[] tankBases;
    [SerializeField] private Sprite[] tankTowers;

    private void Start()
    {
        var randomColor = new Color(Random.Range(0.2f,1f),Random.Range(0.2f,1f),Random.Range(0.2f,1f));
        
        tankBaseAnimator.runtimeAnimatorController = tankBases[Random.Range(0, tankBases.Length)];
        tankBase.color = randomColor;

        tankTower.sprite = tankTowers[Random.Range(0, tankTowers.Length)];
        tankTower.color = randomColor;

        Destroy(this);
    }
    
}
