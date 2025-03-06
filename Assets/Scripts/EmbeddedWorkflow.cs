using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmbeddedWorkflow : MonoBehaviour
{
    public InputAction jumpAction;
    private bool exampleBool;

    // Start is called before the first frame update
    void Start()
    {
        jumpAction.performed += Jump;
        jumpAction.canceled += StopJump;
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.performed -= Jump;
        jumpAction.canceled -= StopJump;
        jumpAction.Disable();
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
        if (exampleBool)
        {

        }
    }
}
