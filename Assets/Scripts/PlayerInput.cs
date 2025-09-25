using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{
    private Shooter shooter;
    private Rigidbody rb;

    [Header("Movimiento")]
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        rb = GetComponent<Rigidbody>();

        // Opcional: bloquea que el Rigidbody rote o caiga
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    // --- Disparo ---
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shooter.Fire();
        }
    }

    // --- Movimiento ---
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Convertir input 2D en vector 3D (X,Z)
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
