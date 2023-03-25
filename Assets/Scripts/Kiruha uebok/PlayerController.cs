using System;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField] private float speed = 5;
    private Rigidbody2D _rigidbody2D;
    protected PhotonView view;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * (speed * Time.deltaTime);
            _rigidbody2D.velocity = moveAmount;
            
            //transform.position += (Vector3)moveAmount;
            
            if(moveInput.x == 0 && moveInput.y == 0) return;
            
            float rotationZ = Mathf.Atan2(moveInput.y,moveInput.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        throw new NotImplementedException();
    }
}
