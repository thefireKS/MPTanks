using UnityEngine;
using Photon.Pun;

public class PlayerTower : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera tankCamera;
    private PhotonView _view;

    [SerializeField] private Transform gunPoint;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        if (!_view.IsMine)
            Destroy(tankCamera.gameObject);
    }

    private void Update()
    {
        if (!_view.IsMine) return;
        
        Vector3 diff = tankCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90f;
            
        transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        gunPoint.rotation = Quaternion.Euler(0f,0f,rotationZ + 90f);

        if (Input.GetButtonDown("Fire1"))
        {
            PhotonNetwork.Instantiate("Bullet", gunPoint.position, gunPoint.rotation);
        }
    }
}
