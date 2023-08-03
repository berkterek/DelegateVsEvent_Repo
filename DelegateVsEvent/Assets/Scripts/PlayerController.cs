using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _damage = 50;
    GameInputActions _input;
    Camera _camera;

    void Awake()
    {
        _input = new GameInputActions();
        _camera = Camera.main;
    }

    void OnEnable()
    {
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
    }

    void Update()
    {
        if (!_input.Player.IsTouch.WasPressedThisFrame()) return;

        var touchPosition = _input.Player.TouchPosition.ReadValue<Vector2>();
        var worldPosition = _camera.ScreenToWorldPoint(touchPosition);
        var raycastHit = Physics2D.Raycast(worldPosition, worldPosition, 0.1f);
        if (raycastHit.collider != null)
        {
            //Debug.Log(raycastHit.collider.gameObject.name);
            var enemy = raycastHit.collider.GetComponent<EnemyController>();
            //enemy.TakeDamage(_damage,HandleOnSuccessDamage,HandleOnFailDamage);
            enemy.TakeDamage(_damage, () => { Debug.Log("Damage Success"); }, () => { Debug.Log("Damage Failed");});
        }
    }

    private void HandleOnSuccessDamage()
    {
        Debug.Log("Damage Success");
    }

    private void HandleOnFailDamage()
    {
        Debug.Log("Damage Failed");
    }
}