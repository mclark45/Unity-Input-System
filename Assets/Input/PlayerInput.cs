using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions _input;

    private void Start()
    {
        InputMapping();
    }

    private void InputMapping()
    {
        _input = new PlayerInputActions();
        _input.Dog.Enable();
        _input.Dog.Bark.performed += Bark_performed;
        _input.Dog.Walk.performed += Walk_performed;
        _input.Dog.Run.performed += Run_performed;
        _input.Dog.Die.performed += Die_performed;
    }

    #region Input Methods
    private void Die_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Died... " + context);
    }

    private void Run_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Running... " + context);
    }

    private void Walk_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Walking " + context);
    }

    private void Bark_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Done Barking... " + context);
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Barking... " + context);
    }
    #endregion 
}
