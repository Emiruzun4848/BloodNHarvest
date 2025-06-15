using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [Header("Movement Settings")]
    [SerializeField] float Gravity = -9.81f;
    [SerializeField] Vector3 moveDirect;
    [SerializeField] float currentGravity;
    [SerializeField] float speed = 1f;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] public float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.2f;
    private bool isDashing = false;
    private bool CanDashable = false;
    private float dashTimer = 0f;
    private Vector3 dashDirection;

    void Start()
    {
        if (ManagerInput.Instance != null)
        {
            ManagerInput.Instance.OnMoveInput += HandleMovement;
            ManagerInput.Instance.onShiftPressed += Dash;

        }

        moveDirect = Vector3.zero;
        controller = GetComponent<CharacterController>();
        CanDashable = true;
        if (dashCooldown < dashDuration)
        {
            dashCooldown = dashDuration;
        }
    }
    private void Update()
    {
        ApplyGravity();
        if (isDashing)
        {
            DashMovement();
        }
        else
        {
            Movement();
        }
    }
    void Movement()
    {
        Vector3 move = moveDirect * speed;
        move *= Time.deltaTime;
        controller.Move(move);
    }
    private void DashMovement()
    {
        Vector3 dashMove = dashDirection * dashSpeed * Time.deltaTime;
        dashMove.y = currentGravity;
        controller.Move(dashMove);
        dashTimer -= Time.deltaTime;
        if (dashTimer <= 0f)
        {
            isDashing = false;
        }
    }
    private void ApplyGravity()
    {
        if (controller.isGrounded && moveDirect.y < 0)
        {
            currentGravity = -2f;
        }
        else
        {
            currentGravity += Gravity * Time.deltaTime;
        }
        controller.Move(new Vector3(0, currentGravity, 0) * Time.deltaTime);
    }
    private void HandleMovement(Vector2 movementInput)
    {
        moveDirect.x = movementInput.x;
        moveDirect.z = movementInput.y;
    }

    public void Dash()
    {
        if (!isDashing && CanDashable)
        {
            isDashing = true;
            dashTimer = dashDuration;
            dashDirection = new Vector3(moveDirect.x, 0, moveDirect.z).normalized;
            if (dashDirection == Vector3.zero)
                dashDirection = transform.forward; // Default forward dash
            CanDashable = false;
            Invoke(nameof(ResetDash), dashCooldown);
        }
    }
    public void ResetDash() => CanDashable = true;
    void OnDestroy()
    {
        if (ManagerInput.Instance != null)
        {
            ManagerInput.Instance.OnMoveInput -= HandleMovement;
            ManagerInput.Instance.onShiftPressed -= Dash;
        }
    }
}