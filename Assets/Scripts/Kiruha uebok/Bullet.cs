using System;
using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        SpawnPlayers.Instance.TeleportPlayer(col.gameObject);
        Destroy(gameObject);
    }
}
