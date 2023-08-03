using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyDataContainerSO _enemyDataContainer;
    [SerializeField] Transform _transform;

    float _moveSpeed;
    int _currentHealth;

    public event System.Action<int,int> OnHealthValueChanged;

    void OnValidate()
    {
        if (_transform == null) _transform = transform;
    }

    void Start()
    {
        var enemyBody = Instantiate(_enemyDataContainer.Prefab, this.transform);
        enemyBody.transform.localPosition = Vector3.zero;
        _moveSpeed = _enemyDataContainer.RandomSpeed;
        _currentHealth = _enemyDataContainer.MaxHealth;
    }

    void Update()
    {
        _transform.Translate(Time.deltaTime * _moveSpeed * Vector3.left);
    }

    public void TakeDamage(int damage, System.Action onSuccessDamage = null, System.Action onFailDamage = null)
    {
        if (Random.Range(0, 100) < 70)
        {
            _currentHealth -= damage;
            OnHealthValueChanged?.Invoke(_currentHealth, _enemyDataContainer.MaxHealth);
            onSuccessDamage?.Invoke();
        }
        else
        {
            onFailDamage?.Invoke();
        }
    }
}