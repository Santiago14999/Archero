using System.Collections.Generic;
using UnityEngine;

namespace ArcheroLike.Units.Enemies
{
    public class EnemiesController : MonoBehaviour
    {
        List<AbstractEnemy> _enemies;

        static EnemiesController _instance;
        public static EnemiesController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<EnemiesController>();

                if (!_instance._isInit)
                    _instance.Init();

                return _instance;
            }
        }

        public List<AbstractEnemy> Enemies => _enemies.FindAll(x => x.IsAlive);

        bool _isInit = false;

        void Awake()
        {
#if UNITY_EDITOR
            if (!_isInit)
                Init();

            foreach (var enemy in FindObjectsOfType<AbstractEnemy>())
                _enemies.Add(enemy);
#endif
        }

        void Init()
        {
            _isInit = true;
            _enemies = new List<AbstractEnemy>();
            AbstractEnemy.EnemyDied += DestroyEnemy;
        }

        void OnDestroy()
        {
            AbstractEnemy.EnemyDied -= DestroyEnemy;
        }

        public void SpawnEnemy(AbstractEnemy enemy, Vector3 position, Quaternion rotation)
        {
            AbstractEnemy spawnedEnemy = Instantiate(enemy, position, rotation);
            _enemies.Add(spawnedEnemy);
        }

        public void DestroyEnemy(AbstractEnemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public bool HasEnemy() => _enemies.Count > 0;
    }
}
