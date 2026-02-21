using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float walkInput = 0.0f;
    public bool jumpInput = false;

    public void UpdateWalkInput(InputAction.CallbackContext ctx)
    {
        walkInput = ctx.ReadValue<float>();
    }

    public void UpdateJumpInput(InputAction.CallbackContext ctx)
    {
        jumpInput = ctx.performed;
    }
}
