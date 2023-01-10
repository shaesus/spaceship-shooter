using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;

    [SerializeField] private Transform _shootPoint;
    private Vector3 _mousePos;
    private Vector3 _lookDirection;

    private Rigidbody _rb => Player.Instance.PlayerRb;

    private void Shoot()
    {
        Instantiate(_rocket, _shootPoint.position, _rb.rotation * Quaternion.Euler(90,0,0));
    }

    private void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = (_mousePos - transform.position).normalized;

        _rb.rotation = Utils.CalculateRotation(_lookDirection);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
