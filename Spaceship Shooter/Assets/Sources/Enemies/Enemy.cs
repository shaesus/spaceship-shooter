using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamagable
{
    public static event Action EnemyDied;

    [SerializeField] private float _moveSpeed = 3f;
    public float MoveSpeed { get { return _moveSpeed; } }

    private EnemyBehavior _behavior;

    public void SetBehavior(EnemyBehavior behavior)
    {
        _behavior = behavior;
    }

    private void Update()
    {
        _behavior?.DoBehavior();
    }

    public void TakeDamage()
    {
        EnemyDied?.Invoke();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player) && player is IDamagable)
        {
            player.TakeDamage();
            TakeDamage();
        }
    }
}
