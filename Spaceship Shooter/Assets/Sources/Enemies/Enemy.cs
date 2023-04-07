using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamagable
{
    public static event Action EnemyDied;

    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private MeshCollider _collider;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private float _moveSpeed = 3f;
    public float MoveSpeed { get { return _moveSpeed; } }

    private EnemyBehavior _behavior;

    private bool _isDead = false;

    public void SetBehavior(EnemyBehavior behavior)
    {
        _behavior = behavior;
    }

    private void Update()
    {
        if (!_isDead)
        {
            _behavior?.DoBehavior();
        }
    }

    public void Die()
    {
        _isDead = true;
        EnemyDied?.Invoke();

        if (_trail != null)
        {
            _meshRenderer.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, _trail.startLifetime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            player.Die();
            Die();
        }
    }
}
