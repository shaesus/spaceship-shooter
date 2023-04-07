using UnityEngine;

public class PlayerRocket : Rocket
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
