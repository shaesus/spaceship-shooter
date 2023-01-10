using UnityEngine;

public abstract class EnemyBehavior
{
    protected Enemy _enemy;

    protected Rigidbody _enemyRb;

    protected Transform _target;

    public EnemyBehavior(Enemy enemy)
    {
        _enemy = enemy;

        _enemyRb = enemy.GetComponent<Rigidbody>();

        _target = Player.Instance.transform;
    }

    public abstract void DoBehavior();
}
