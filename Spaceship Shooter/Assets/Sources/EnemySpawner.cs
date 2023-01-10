using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    [SerializeField] private LayerMask _enemyLayers;

    private Vector3 _center = Vector3.zero;

    [SerializeField] private float _minDistanceBetweenEnemies = 1f;
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

            Vector3 pos;

            while (true)
            {
                pos = CalculateSpawnPos(randomEnemy);
                
                if (Physics.OverlapSphere(pos, _minDistanceBetweenEnemies, _enemyLayers).Length == 0)
                {
                    break;
                }
            }

            var enemy = Instantiate(randomEnemy, pos, Quaternion.identity);
            BehaviorInitializer.Instance.InitializeBehavior(enemy);
        }
    }

    private Vector3 CalculateSpawnPos(Enemy randomEnemy)
    {
        var rndAngle = Random.Range(0, 360);
        var offset = new Vector3(Mathf.Cos(rndAngle) * _spawnRadius, 0, Mathf.Sin(rndAngle) * _spawnRadius);

        if (randomEnemy.CompareTag("StayAndShoot"))
        {
            var divisionCoefficient = Random.Range(1.5f, 5f);
            offset /= divisionCoefficient;
        }

        return _center + offset;
    }
}
