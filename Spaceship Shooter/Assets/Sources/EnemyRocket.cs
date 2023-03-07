using UnityEngine;

public class EnemyRocket : Rocket
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.TakeDamage();
            Destroy(gameObject);
        }
    }
}
