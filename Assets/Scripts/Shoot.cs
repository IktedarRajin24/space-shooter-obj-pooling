using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private ObjectPooler bulletPool;
    [SerializeField] private int bulletSpeed = 10;
    private InputSystem_Actions playerInput;
    private void Awake()
    {
        playerInput = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Shoot.performed += OnShoot;
    }
    private void OnDisable()
    {
        playerInput.Player.Shoot.performed -= OnShoot;
        playerInput.Disable();

    }
    private void OnShoot(InputAction.CallbackContext context)
    {
        ShootBullet();
    }
    private void ShootBullet()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
}
