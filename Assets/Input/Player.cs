using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;
    private MeshRenderer _render;

    void Start()
    {
        _input = new PlayerInputActions();

        _input.Player.Enable();

        _input.Player.ColorChange.performed += ColorChange_performed;
        _input.Player.SwitchMaps.performed += SwitchMaps_performed;

        _render = GetComponent<MeshRenderer>();
    }

    private void SwitchMaps_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _input.Player.Disable();
        _input.Driving.Enable();
    }

    private void ColorChange_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_render != null)
            _render.material.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        Rotating();
        Driving();
    }

    private void Rotating()
    {
        var rotateDirection = _input.Player.Rotate.ReadValue<float>();

        transform.Rotate(Vector3.up * Time.deltaTime * 30f * rotateDirection);
    }

    private void Driving()
    {
        var move = _input.Driving.Movement.ReadValue<Vector2>();

        transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime * 5f);
    }
}
