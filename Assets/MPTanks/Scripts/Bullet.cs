using System;
using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    [SerializeField] private float bulletSpeed;
    private PhotonView _view;
    private SpriteRenderer _spriteRenderer;
    private void OnEnable()
    {
        _view = GetComponent<PhotonView>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        var color = new Color((float)_view.Owner.CustomProperties["Red"],(float)_view.Owner.CustomProperties["Green"],
            (float)_view.Owner.CustomProperties["Blu"]);
        _spriteRenderer.color = color;
        
        Destroy(gameObject,5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (bulletSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
