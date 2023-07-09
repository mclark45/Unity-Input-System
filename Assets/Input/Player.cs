using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputAction _input;
    private bool _jumped = false;
    void Start()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Jump.canceled += Jump_canceled;
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //light jump or none
        var forceEffect = context.duration;
        GetComponent<Rigidbody>().AddForce(Vector3.up * (5f * (float)forceEffect), ForceMode.Impulse);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Full Jump");
        _jumped = true;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
