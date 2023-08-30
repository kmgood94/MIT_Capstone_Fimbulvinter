using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public void HandleInteract(InputAction.CallbackContext context)
    {
        print(context.phase);

        if (context.performed)
        {
            print("Interact performed");
        }
        else if (context.started)
        {
            print("Interact started");
        }
        else if (context.canceled)
        {
            print("Interact canceled");
        }
    }
}
