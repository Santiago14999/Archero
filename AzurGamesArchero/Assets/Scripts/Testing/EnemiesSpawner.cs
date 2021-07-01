using UnityEngine;
using ArcheroLike.Units.Enemies;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] AbstractEnemy _enemyToSpawn;
    [SerializeField] Transform _spawnPoint;

    public void SpawnEnemy()
    {
        if (_enemyToSpawn == null || _spawnPoint == null)
            throw new System.Exception("EnemyToSpawn or SpawnPoint is not set in EnemiesSpawner.");

        EnemiesController.Instance.SpawnEnemy(_enemyToSpawn, _spawnPoint.position, _spawnPoint.rotation);
    }
}
