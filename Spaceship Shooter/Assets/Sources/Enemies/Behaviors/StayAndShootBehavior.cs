using UnityEngine;

public class StayAndShootBehavior : EnemyBehavior
{
    private Vector3 _directionToPlayer;

    private readonly Rocket _rocket;

    private readonly float _shootCd;
    private float _timeSinceLastShot = 0f;

    private readonly GameObject _shootPoint;

    public StayAndShootBehavior(Enemy enemy, Vector3 spawnPointOffset, float shootCd, Rocket rocket) : base(enemy) 
    {
        _rocket = rocket;

        _shootCd = shootCd;

        _shootPoint = new GameObject();
        _shootPoint.transform.parent = _enemy.transform;
        _shootPoint.transform.localPosition = spawnPointOffset;
    }

    public override void DoBehavior()
    {
        TryShoot();

        Rotate();
    }

    private void Rotate()
    {
        _directionToPlayer = (_target.position - _enemyRb.position).normalized;

        _enemyRb.rotation = Utils.CalculateRotation(_directionToPlayer);
    }

    private void TryShoot()
    {
        if (_timeSinceLastShot >= _shootCd)
        {
            Utils.SpawnPrefab(_rocket, _shootPoint.transform.position, _enemyRb.rotation * Quaternion.Euler(90, 0, 0));
            _timeSinceLastShot = 0;
        }

        _timeSinceLastShot += Time.deltaTime;
    }
}
