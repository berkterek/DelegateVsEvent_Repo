using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyDataContainerSO _enemyDataContainer;
    [SerializeField] Transform _transform;

    float _moveSpeed;

    void OnValidate()
    {
        if (_transform == null) _transform = transform;
    }

    void Start()
    {
        var enemyBody = Instantiate(_enemyDataContainer.Prefab, this.transform);
        enemyBody.transform.localPosition = Vector3.zero;
        _moveSpeed = _enemyDataContainer.RandomSpeed;
    }

    void Update()
    {
        _transform.Translate(Time.deltaTime * _moveSpeed * Vector3.left);
    }
}