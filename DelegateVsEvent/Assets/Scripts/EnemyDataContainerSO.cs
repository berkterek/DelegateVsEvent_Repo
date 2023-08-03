using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data Container", menuName = "Terek Gaming/Data Container/Enemy Container")]
public class EnemyDataContainerSO : ScriptableObject
{
    [SerializeField] GameObject[] _prefabs;
    [SerializeField] float _minSpeed = 1f;
    [SerializeField] float _maxSpeed = 5f;
    
    public float RandomSpeed => Random.Range(_minSpeed, _maxSpeed);
    public GameObject Prefab => _prefabs[Random.Range(0,_prefabs.Length)];
}