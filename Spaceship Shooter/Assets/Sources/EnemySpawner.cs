using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    private Vector3 _center = Vector3.zero;

    [SerializeField] private float _spawnCooldown;
    private float _spawnRadius;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCooldown);

            var randomEnemy = _enemies[Random.Range(0, _enemies.Length)];

            if (randomEnemy.CompareTag("StayAndShoot"))
            {
                _spawnRadius = Playground.Instance.MaxX / 2;
            }
            else
            {
                _spawnRadius = Playground.Instance.MaxX;
            }

            var rndAngle = Random.Range(0, 360);

            var offset = new Vector3(Mathf.Cos(rndAngle) * _spawnRadius, 0, Mathf.Sin(rndAngle) * _spawnRadius);

            var enemy = Instantiate(randomEnemy, _center + offset, Quaternion.identity);
            BehaviorInitializer.InitializeBehavior(enemy);
        }
    }
}
