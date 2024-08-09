using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPauseAction;
    private Player_Controller playerController;

    private void Awake()
    {
        playerController = new Player_Controller();
        playerController.Player.Enable();

        playerController.Player.Pause.performed += Paused_performed;
    }

    private void OnDestroy()
    {
        playerController.Player.Pause.performed -= Paused_performed;

        playerController.Dispose();
    }

    private void Paused_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector = playerController.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
