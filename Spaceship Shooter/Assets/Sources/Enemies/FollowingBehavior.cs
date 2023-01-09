using UnityEngine;

public class FollowingBehavior : EnemyBehavior
{
    private readonly Transform _target;

    private readonly Rigidbody _enemyRb;

    private Vector3 _direction;

    public FollowingBehavior (Enemy enemy, Transform target)
    {
        _enemy = enemy;

        _enemyRb = _enemy.GetComponent<Rigidbody>();

        _target = target;
    }

    public override void DoBehavior()
    {
        Follow();
        Rotate();
    }

    private void Follow()
    {
        _direction = (_target.position - _enemyRb.position).normalized;
        _enemyRb.MovePosition(_enemyRb.position + _direction * _enemy.MoveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        var angle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        _enemyRb.rotation = Quaternion.Euler(0, angle, 0);
    }
}
