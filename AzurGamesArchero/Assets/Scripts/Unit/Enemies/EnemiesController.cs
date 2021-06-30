using System.Collections.Generic;
using System.Linq;
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
            Destroy(enemy.gameObject);
        }

        public bool HasEnemy() => _enemies.Count > 0;

        public AbstractEnemy GetClosestEnemy(Vector3 from)
        {
            return _enemies.OrderBy(x => Vector3.SqrMagnitude(from - x.transform.position)).FirstOrDefault();
        }

        public AbstractEnemy GetClosestEnemy(AbstractEnemy from)
        {
            return _enemies.OrderBy(x => Vector3.SqrMagnitude(from.transform.position - x.transform.position)).First(x => x != from);
        }
    }
}
