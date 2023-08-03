using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawn Data Container", menuName = "Terek Gaming/Data Container/Enemy Data Container")]
public class EnemySpawnDataContainerSO : ScriptableObject
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _minSpanwTime;
    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minMaxYPositionValue = 4f;
    [SerializeField] float _xPositionValue = 13f;
    
    public float RandomSpawnTime => Random.Range(_minSpanwTime, _maxSpawnTime);
    public float XPositionValue => _xPositionValue;
    public float MinMaxYPositionValue => _minMaxYPositionValue;
    public GameObject Prefab => _prefab;
}