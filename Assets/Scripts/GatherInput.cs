using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        //myControls.PlayerNormal.Enable();
        //myControls.PlayerNormal.Jump.Enable();

        myControls.PlayerNormal.Jump.performed += JumpExample;
        myControls.PlayerNormal.Jump.canceled += JumpStopExample;

        myControls.PlayerNormal.Attack.performed += AttackExample;
        myControls.PlayerNormal.Attack.canceled += AttackStopExample;

        myControls.Enable();
    }

    private void OnDisable()
    {
        myControls.Disable();

        myControls.PlayerNormal.Jump.performed -= JumpExample;
        myControls.PlayerNormal.Jump.canceled -= JumpStopExample;

        myControls.PlayerNormal.Attack.performed -= AttackExample;
        myControls.PlayerNormal.Attack.canceled -= AttackStopExample;
    }


    void Update()
    {
        valueX = myControls.PlayerNormal.MoveHorizontal.ReadValue<float>();
    }

    private void JumpExample(InputAction.CallbackContext value)
    {
        //tryToJump = value.ReadValueAsButton();
        tryToJump = true;
    }

    private void JumpStopExample(InputAction.CallbackContext value)
    {
        //tryToJump = value.ReadValueAsButton();
        tryToJump = false;
    }

    private void AttackExample(InputAction.CallbackContext value)
    {
        //tryToJump = value.ReadValueAsButton();
        tryToAttack = true;
    }

    private void AttackStopExample(InputAction.CallbackContext value)
    {
        //tryToJump = value.ReadValueAsButton();
        tryToAttack = false;
    }
}
