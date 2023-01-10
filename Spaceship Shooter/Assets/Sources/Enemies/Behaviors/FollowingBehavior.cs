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
        _enemyRb.rotation = Utils.CalculateRotation(_directionToPlayer);
    }
}
