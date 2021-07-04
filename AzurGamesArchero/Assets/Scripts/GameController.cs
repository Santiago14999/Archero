using UnityEngine;
using ArcheroLike.Units.Player;
using ArcheroLike.Units.Enemies;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform _playerSpawnPoint;
    [SerializeField] Transform[] _enemySpawnPoints;
    [SerializeField] AbstractEnemy _goblinPrefab;
    [SerializeField] LevelGates _levelGates;
    [SerializeField] Transform _player;

    int _currentLevel = 0;

    static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                FindObjectOfType<GameController>();

            return _instance;
        }
    }

    void Awake()
    {
        AbstractEnemy.EnemyDied += CheckIfLevelCompleted;
        _levelGates.PlayerEnteredPortal += NextLevel;
    }

    void OnDestroy()
    {
        AbstractEnemy.EnemyDied -= CheckIfLevelCompleted;
        _levelGates.PlayerEnteredPortal -= NextLevel;
    }

    void Start()
    {
        NextLevel();
    }

    void CheckIfLevelCompleted(AbstractEnemy enemy)
    {
        if (!EnemiesController.Instance.HasEnemy())
            OnLevelComplete();
    }

    void OnLevelComplete()
    {
        _levelGates.OpenGates();
    }

    void NextLevel()
    {
        _currentLevel++;
        InitLevel();
    }

    void InitLevel()
    {
        _levelGates.CloseGates();
        MovePlayerToStart();
        EnemiesController enemiesController = EnemiesController.Instance;
        enemiesController.DestroyEnemies();
        foreach (var spawnPoint in _enemySpawnPoints)
        {
            enemiesController.SpawnEnemy(_goblinPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    void MovePlayerToStart()
    {
        var character = _player.GetComponent<CharacterController>();
        character.enabled = false;
        _player.transform.position = _playerSpawnPoint.position;
        character.enabled = true;
    }
}
