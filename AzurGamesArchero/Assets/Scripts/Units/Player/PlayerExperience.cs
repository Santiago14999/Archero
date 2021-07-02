using System;
using UnityEngine;

namespace ArcheroLike.Units.Player
{
    public class PlayerExperience : MonoBehaviour
    {
        public event Action PlayerGainExperience;
        public event Action PlayerLeveledUp;

        int _level;
        int _experience;
        public int Level => _level;
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                if (_experience >= NextLevelExperience)
                {
                    _experience %= NextLevelExperience;
                    _level++;
                    PlayerLeveledUp?.Invoke();
                }
                PlayerGainExperience?.Invoke();
            }
        }
        public int NextLevelExperience => _level * 2;

        private void Start()
        {
            _experience = 0;
            _level = 1;
            Enemies.AbstractEnemy.EnemyDied += OnEnemyDied;
        }

        void OnEnemyDied(Enemies.AbstractEnemy enemy)
        {
            Experience += enemy.Experience;
        }
    }
}
