using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Inputs input;

    public Vector2 Get1DMovement => input.Player._1DMovement.ReadValue<Vector2>();
    public bool GetSpaceButtonPressed => input.Player.Shoot.WasPressedThisFrame();


    private void OnEnable()
    {
        input = new Inputs();
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();;
    }
}
