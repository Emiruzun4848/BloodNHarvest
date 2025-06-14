using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [SerializeField]  float  Gravity = -9.81f;
    [SerializeField] Vector3 moveDirect;
    [SerializeField] float currentGravity;
    [SerializeField] float speed = 1f;

    void Start()
    {
        if (ManagerInput.Instance != null)
        {
            ManagerInput.Instance.OnMoveInput += HandleMovement;
            ManagerInput.Instance.onShiftPressed += Dash;

        }

        moveDirect = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Movement();
    }
    void Movement()
    {
        ApplyGravity();
        Vector3 move = moveDirect * speed;
        move.y = currentGravity;
        move *= Time.deltaTime;
        controller.Move(move);
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
    }
    private void HandleMovement(Vector2 movementInput)
    {
        moveDirect.x = movementInput.x;
        moveDirect.z = movementInput.y;
    }

    public void Dash()
    {

    }

    void OnDestroy()
    {
        if (ManagerInput.Instance != null)
        {
            ManagerInput.Instance.OnMoveInput -= HandleMovement;
            ManagerInput.Instance.onShiftPressed -= Dash;
        }
    }
}