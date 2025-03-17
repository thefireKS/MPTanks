using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [Header("Objects")]
    [SerializeField] private Transform tankRenderer;
    [SerializeField] private GameObject invulnerabilityShield;
    [SerializeField] private BoxCollider2D tankCollider;
    [Space(10),Header("Numbers")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float invulnerabilityTime = 1f;
    [SerializeField] private float uncontrolledTime = 0.6f;
    
    private Rigidbody2D _rigidbody2D;
    private PhotonView _view;

    private bool isControllable = true;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _view = tankRenderer.GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!_view.IsMine) return;
        if (!isControllable) return;
        
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        var moveAmount = moveInput.normalized * speed;
        _rigidbody2D.velocity = moveAmount;
        
        if(moveInput is { x: 0, y: 0 }) return;
        var rotationZ = Mathf.Atan2(moveInput.y,moveInput.x) * Mathf.Rad2Deg - 90f;
        
        tankRenderer.rotation = Quaternion.Euler(0f,0f,rotationZ);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Bullet")) return;
        SpawnPlayers.Instance.TeleportPlayer(gameObject);
        StartCoroutine(Invulnerability());
    }

    private IEnumerator Invulnerability()
    {
        _rigidbody2D.velocity = Vector2.zero;
        isControllable = false;
        tankCollider.enabled = false;
        invulnerabilityShield.SetActive(true);
        yield return new WaitForSeconds(uncontrolledTime);
        isControllable = true;
        yield return new WaitForSeconds(invulnerabilityTime - uncontrolledTime);
        tankCollider.enabled = true;
        invulnerabilityShield.SetActive(false);
    }
}
