using UnityEngine;

public class FollowingBehavior : EnemyBehavior
{
    private Vector3 _directionToPlayer;

    public FollowingBehavior(Enemy enemy) : base(enemy) { }

    public override void DoBehavior()
    {
        _directionToPlayer = (_target.position - _enemyRb.position).normalized;

        Move();
        Rotate();
    }

    private void Move()
    {
        _enemyRb.MovePosition(_enemyRb.position + _directionToPlayer * _enemy.MoveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        var angleToPlayer = Mathf.Atan2(_directionToPlayer.x, _directionToPlayer.z) * Mathf.Rad2Deg;
        _enemyRb.rotation = Quaternion.Euler(0, angleToPlayer, 0);
    }
}
