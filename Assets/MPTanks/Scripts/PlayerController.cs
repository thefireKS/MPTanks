using System;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform tankRenderer;
    [SerializeField] private GameObject camera;
    [Space(5)]
    [SerializeField] private float speed = 5;
    private Rigidbody2D _rigidbody2D;
    private PhotonView view;
    //private Animator animator;

    private bool isControllable = true;
    private float controlTimer = 0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        view = tankRenderer.GetComponent<PhotonView>();
        //animator = tankRenderer.GetComponent<Animator>();
    }

    public override void OnConnected()
    {
        base.OnConnected();
        if(!photonView.IsMine)
            Destroy(camera);
    }

    private void Update()
    {
        //controlTimer += Time.deltaTime;
        //if (controlTimer > 0.5f)
        //isControllable = true;
        //if(controlTimer > 1f)
            //animator.SetBool("Respawn",false);
        
        if (!view.IsMine) return;
        if (!isControllable) return;
        
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        var moveAmount = moveInput.normalized * speed;
        _rigidbody2D.velocity = moveAmount;
        
        //animator.SetBool("IsMoving",moveInput.magnitude != 0);
        
        if(moveInput.x == 0 && moveInput.y == 0) return;
        var rotationZ = Mathf.Atan2(moveInput.y,moveInput.x) * Mathf.Rad2Deg - 90f;
        
        tankRenderer.rotation = Quaternion.Euler(0f,0f,rotationZ);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Bullet")) return;
        SpawnPlayers.Instance.TeleportPlayer(gameObject);
        isControllable = false;
        controlTimer = 0f;
        //animator.SetBool("Respawn",true);
    }
}
