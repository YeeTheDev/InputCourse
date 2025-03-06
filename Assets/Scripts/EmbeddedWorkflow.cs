using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmbeddedWorkflow : MonoBehaviour
{
    public InputAction jumpAction;
    public InputAction moveAction;
    private bool exampleBool;

    // Start is called before the first frame update
    void Start()
    {
        jumpAction.performed += Jump;
        jumpAction.canceled += StopJump;
        jumpAction.Enable();

        moveAction.performed += Move;
        moveAction.canceled += StopMove;
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        moveAction.performed -= Move;
        moveAction.canceled -= StopMove;

        jumpAction.Disable();
        jumpAction.performed -= Jump;
        jumpAction.canceled -= StopJump;
    }

    private void Move(InputAction.CallbackContext value)
    {
        Debug.Log(value.ReadValue<Vector2>().normalized);
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        Debug.Log(value.ReadValue<Vector2>().normalized);
    }

    private void Jump(InputAction.CallbackContext value)
    {
        exampleBool = value.ReadValueAsButton();
        Debug.Log("Jump performed and bool is: "+ exampleBool);
    }

    private void StopJump(InputAction.CallbackContext value)
    {
        exampleBool = value.ReadValueAsButton();
        Debug.Log("Jump canceled and bool is: " + exampleBool);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveAction.ReadValue<Vector2>().normalized);

        if (exampleBool)
        {

        }
    }
}
