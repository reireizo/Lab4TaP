using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, PlayerControls.IKeyboardActions
{
    private PlayerControls playerControls;
    public static UnityAction onShoot = delegate { };
    public static UnityAction onRestart = delegate { };
    public static UnityAction<Vector2> onMove = delegate { };
    void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Keyboard.SetCallbacks(this);
        }
        playerControls.Keyboard.Enable();
    }

    void OnDisable()
    {
        playerControls.Keyboard.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        onMove(context.ReadValue<Vector2>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onShoot();
        }
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            onRestart();
        }
    }  
}
