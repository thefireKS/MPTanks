using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomTankCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] protected SpriteRenderer tankBase;
    [SerializeField] protected SpriteRenderer tankTower;
    [SerializeField] protected Animator tankBaseAnimator;
    [SerializeField] protected AnimatorOverrideController[] tankBases;
    [SerializeField] protected Sprite[] tankTowers;

    private float r, g, b;
    protected PhotonView view;

    private string randomBase, randomTower;

    private Hashtable _customProperties = new Hashtable
    {
        {"R", (float)1f},
        {"G", (float)1f},
        {"B", (float)1f},
        {"tankBase", (string)"Base1"},
        {"tankTower", (string)"gun1"}
    };

    public override void OnEnable()
    {
        view = GetComponent<PhotonView>();
        
        PhotonNetwork.AddCallbackTarget(this);
        
        if(!view.IsMine) return;
        InitializeTexturesAndColor();
    }

    private void InitializeTexturesAndColor()
    {
        r = Random.Range(0.2f, 1f);
        g = Random.Range(0.2f, 1f);
        b = Random.Range(0.2f, 1f);

        randomBase = tankBases[Random.Range(0, tankBases.Length)].name;
        randomTower = tankTowers[Random.Range(0, tankTowers.Length)].name;

        _customProperties["R"] = r;
        _customProperties["G"] = g;
        _customProperties["B"] = b;

        _customProperties["tankBase"] = randomBase;
        _customProperties["tankTower"] = randomTower;
        
        if(!view.IsMine) return;
        PhotonNetwork.SetPlayerCustomProperties(_customProperties);
        //view.RPC("SetTexturesAndColor", RpcTarget.All, r, g, b, randomBase, randomTower);
    }
}