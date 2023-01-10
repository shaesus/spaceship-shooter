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
        _spawnRadius = Playground.Instance.MaxX;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCooldown);

            var randomEnemy = _enemies[Random.Range(0, _enemies.Length)];

            Vector3 offset;
            var rndAngle = Random.Range(0, 360);
            if (randomEnemy.CompareTag("StayAndShoot"))
            {
                offset = new Vector3(Mathf.Cos(rndAngle) * _spawnRadius / 2, 0, Mathf.Sin(rndAngle) * _spawnRadius / 2);
            }
            else
            {
                offset = new Vector3(Mathf.Cos(rndAngle) * _spawnRadius, 0, Mathf.Sin(rndAngle) * _spawnRadius);
            }

            var enemy = Instantiate(randomEnemy, _center + offset, Quaternion.identity);
            BehaviorInitializer.Instance.InitializeBehavior(enemy);
        }
    }
}
