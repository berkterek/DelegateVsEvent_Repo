using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] Image _healthBarFiller;
    [SerializeField] EnemyController _enemyController;

    void OnValidate()
    {
        if (_healthBarFiller == null) _healthBarFiller = GetComponent<Image>();
    }

    void OnEnable()
    {
        _enemyController.OnHealthValueChanged += HandleOnHealthValueChanged;
    }

    void OnDisable()
    {
        _enemyController.OnHealthValueChanged -= HandleOnHealthValueChanged;
    }
    
    void HandleOnHealthValueChanged(int currentHealth, int maxHealth)
    {
        _healthBarFiller.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
