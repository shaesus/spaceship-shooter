using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Rocket : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime = 5f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + transform.up * _moveSpeed * Time.fixedDeltaTime);
    }

    protected abstract void OnTriggerEnter(Collider other);
}
