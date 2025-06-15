using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ManagerInput : MonoBehaviour
{
    public static ManagerInput Instance { get; private set; }
    private BNH_InputSystem gameInputSystem;
    public event Action<Vector2> OnMoveInput;
    public event Action<bool> OnMouseClickInput;
    public event Action onShiftPressed;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //Þimdilik Gerek Yok
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameInputSystem = new BNH_InputSystem();

        gameInputSystem.PlayerControl.MoveLook.performed += ctx => OnMoveInput?.Invoke(ctx.ReadValue<Vector2>());
        gameInputSystem.PlayerControl.MoveLook.canceled += ctx => OnMoveInput?.Invoke(Vector2.zero);

        gameInputSystem.PlayerControl.MouseLeftClick.started += ctx => OnMouseClickInput?.Invoke(true);
        gameInputSystem.PlayerControl.MouseLeftClick.canceled += ctx => OnMouseClickInput?.Invoke(false);

        gameInputSystem.PlayerControl.Shift.started += ctx => onShiftPressed?.Invoke();


    }
    #region Return Functions
    public Vector2 GetMousePosition() => gameInputSystem.PlayerControl.MousePos.ReadValue<Vector2>();
    public bool isPressedMouseClick() => gameInputSystem.PlayerControl.MouseLeftClick.WasPressedThisFrame();
    public bool isHoldMouseClick() => gameInputSystem.PlayerControl.MouseLeftClick.IsPressed();
    public bool isHoldControlButton() => gameInputSystem.PlayerControl.Control.IsPressed();
   
    public RaycastHit? GetMouseHit()
{
    if (EventSystem.current.IsPointerOverGameObject())
        return null;
    Vector3 mousePosition = GetMousePosition();
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(mousePosition);
    if (Physics.Raycast(ray, out hit))
    {
        return hit;
    }
    return null;
}



#endregion

#region Enable-Disable
private void OnEnable()
{
    gameInputSystem.Enable();
}
private void OnDisable()
{
    gameInputSystem.Disable();
}
    #endregion


}
