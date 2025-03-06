using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    [SerializeField] InputActionAsset actionAsset;

    private InputAction jumpAction;
    private InputAction moveAction;
    private InputAction attackAction;
    private InputActionMap playerNormal;

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;

    private void Awake()
    {
        playerNormal = actionAsset.FindActionMap("PlayerNormal");
        jumpAction = playerNormal.FindAction("Jump");
        moveAction = playerNormal.FindAction("MoveHorizontal");
        attackAction = playerNormal.FindAction("Attack");
    }

    private void OnEnable()
    {
        jumpAction.performed += JumpExample;
        jumpAction.canceled += JumpStopExample;

        attackAction.performed += AttackExample;
        attackAction.canceled += AttackStopExample;

        actionAsset.Enable();
        //playerNormal.Enable();
        //jumpAction.Enable();
    }

    private void OnDisable()
    {
        actionAsset.Disable();

        jumpAction.performed -= JumpExample;
        jumpAction.canceled -= JumpStopExample;

        attackAction.performed -= AttackExample;
        attackAction.canceled -= AttackStopExample;
        //playerNormal.Disable();
        //jumpAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        valueX = moveAction.ReadValue<float>();
        Debug.Log("valueX: " + valueX);
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
