using UnityEngine;

public class StraightLineMovementBehavior : EnemyBehavior
{
    private readonly float _maxAngleDifference;

    private readonly Vector3 _moveDirection;

    private readonly float _lifeTime;
    private float _timeSinceInitialization;

    public StraightLineMovementBehavior(Enemy enemy, float maxAngleDiffernce, float lifeTime) : base(enemy)
    {
        _maxAngleDifference = maxAngleDiffernce;

        _moveDirection = CalculateDirection();
        _enemyRb.rotation = Utils.CalculateRotation(_moveDirection);

        _lifeTime = lifeTime;
        _timeSinceInitialization = 0f;
    }

    public override void DoBehavior()
    {
        _timeSinceInitialization += Time.deltaTime;
        if (_timeSinceInitialization >= _lifeTime)
        {
            Utils.DestroyGO(_enemy.gameObject);
        }

        Move();
    }

    private void Move()
    {
        _enemyRb.MovePosition(_enemyRb.position + _moveDirection * _enemy.MoveSpeed * Time.deltaTime);
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
