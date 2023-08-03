using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] EnemySpawnDataContainerSO _enemySpawnerData;

    float _maxTime;
    float _currentTime;

    void Start()
    {
        SetRandomTime();
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxTime)
        {
            SetRandomTime();
            var enemy = Instantiate(_enemySpawnerData.Prefab, this.transform);
            enemy.transform.position = new Vector3
            (
                _enemySpawnerData.XPositionValue,
                Random.Range(-_enemySpawnerData.MinMaxYPositionValue, _enemySpawnerData.MinMaxYPositionValue),
                0f
            );
        }
    }

    private void SetRandomTime()
    {
        _maxTime = _enemySpawnerData.RandomSpawnTime;
        _currentTime = 0f;
    }
}