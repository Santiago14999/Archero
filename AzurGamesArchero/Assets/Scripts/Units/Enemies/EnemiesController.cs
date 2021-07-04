using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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

        bool _isInit = false;

        public List<AbstractEnemy> Enemies => _enemies.FindAll(x => x.IsAlive);

        void Init()
        {
            _isInit = true;
            _enemies = new List<AbstractEnemy>();
        }

        public void SpawnEnemy(AbstractEnemy enemy, Vector3 position, Quaternion rotation)
        {
            AbstractEnemy spawnedEnemy = Instantiate(enemy, position, rotation);
            _enemies.Add(spawnedEnemy);
        }

        public void DestroyEnemies()
        {
            _enemies.ForEach(x => Destroy(x.gameObject));
            _enemies.Clear();
        }

        public bool HasEnemy() => _enemies.Any(x => x.IsAlive);
    }
}
