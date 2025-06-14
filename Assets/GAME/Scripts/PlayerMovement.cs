using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] float Gravity = -9.81f;
    [SerializeField] Vector3 moveDirect;
    [SerializeField] float Speed = 1f;

    void Start()
    {
        if (ManagerInput.Instance != null)
            ManagerInput.Instance.OnMoveInput += HandleMovement;

        moveDirect = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        ApplyGravity();
        controller.Move(moveDirect * Time.deltaTime);
        

    }
    private void ApplyGravity()
    {
        if (controller.isGrounded && moveDirect.y < 0)
        {
            moveDirect.y = -2f; // Yere yapışık kalması için küçük negatif değer
        }
        else
        {
            moveDirect.y += Gravity * Time.deltaTime;
        }
    }
    private void HandleMovement(Vector2 movementInput)
    {
        moveDirect.x = movementInput.x * Speed;
        moveDirect.z = movementInput.y * Speed;
    }

    void OnDestroy()
    {
        if (ManagerInput.Instance != null)
            ManagerInput.Instance.OnMoveInput -= HandleMovement;
    }
}