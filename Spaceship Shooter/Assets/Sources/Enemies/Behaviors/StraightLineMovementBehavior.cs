using UnityEngine;

public class StraightLineMovementBehavior : EnemyBehavior
{
    private readonly float _maxAngleDifference;

    private readonly Vector3 _moveDirection;

    public StraightLineMovementBehavior(Enemy enemy, float angleRange) : base(enemy)
    {
        _maxAngleDifference = angleRange;

        _moveDirection = CalculateDirection();

        _enemyRb.rotation = CalculateRotation();
    }

    public override void DoBehavior()
    {
        Move();
    }

    private void Move()
    {
        _enemyRb.MovePosition(_enemyRb.position + _moveDirection * _enemy.MoveSpeed * Time.deltaTime);
    }

    private Quaternion CalculateRotation()
    {
        var angle = Mathf.Atan2(_moveDirection.x, _moveDirection.z) * Mathf.Rad2Deg;

        return Quaternion.Euler(0, angle, 0);
    }

    private Vector3 CalculateDirection()
    {
        var directionToPlayer = _target.position - _enemyRb.position;
        var angleToPlayer = Mathf.Atan2(directionToPlayer.z, directionToPlayer.x) * Mathf.Rad2Deg;
        var randomAngleRad = Random.Range(angleToPlayer - _maxAngleDifference, angleToPlayer + _maxAngleDifference) / Mathf.Rad2Deg;

        var result = new Vector3(Mathf.Cos(randomAngleRad), 0,
            Mathf.Sin(randomAngleRad)).normalized;

        return result;
    }
}
