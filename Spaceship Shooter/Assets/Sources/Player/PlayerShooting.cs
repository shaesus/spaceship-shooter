using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Vector3 _mousePos;
    private Vector3 _lookDirection;

    private Rigidbody _rb => Player.Instance.PlayerRb;

    private void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = (_mousePos - transform.position).normalized;

        var angle = Mathf.Atan2(_lookDirection.x, _lookDirection.z) * Mathf.Rad2Deg;
        _rb.rotation = Quaternion.Euler(0, angle, 0);
    }
}
