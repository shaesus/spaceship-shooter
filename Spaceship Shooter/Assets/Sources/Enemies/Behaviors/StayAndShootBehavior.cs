using UnityEngine;

public class StayAndShootBehavior : EnemyBehavior
{
    private Vector3 _directionToPlayer;

    public StayAndShootBehavior(Enemy enemy) : base(enemy) { }

    public override void DoBehavior()
    {
        //TODO: Shooting

        _directionToPlayer = (_target.position - _enemyRb.position).normalized;

        Rotate();
    }

    private void Rotate()
    {
        var angleToPlayer = Mathf.Atan2(_directionToPlayer.x, _directionToPlayer.z) * Mathf.Rad2Deg;
        _enemyRb.rotation = Quaternion.Euler(0, angleToPlayer, 0);
    }
}
