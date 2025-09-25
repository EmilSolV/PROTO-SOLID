using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(IWeapon))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{
    private IWeapon shooter;
    private Rigidbody rb;

    [Header("Movimiento")]
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    private void Awake()
    {
        shooter = GetComponent<IWeapon>();
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shooter.Fire();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
