using UnityEngine;

public class PlayerRocket : Rocket
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy) && enemy is IDamagable)
        {
            enemy.TakeDamage();
            Destroy(gameObject);
        }
    }
}
