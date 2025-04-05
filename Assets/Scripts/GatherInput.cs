using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    private InputActionMap playerNormalActionMap;
    private InputAction move;
    private InputAction moveVertical;
    private InputAction jump;
    private InputAction attack;
    private InputAction specialAttack;

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;

    private void OnEnable()
    {
        playerNormalActionMap = playerInput.actions.FindActionMap("PlayerNormal");
        move = playerInput.actions["MoveHorizontal"];
        moveVertical = playerInput.actions["MoveVertical"];
        jump = playerInput.actions["Jump"];
        attack = playerInput.actions["Attack"];
        specialAttack = playerInput.actions["SpecialAttack"];

        jump.performed += JumpExample;

        attack.performed += AttackExample;
        attack.canceled += AttackStopExample;

        specialAttack.performed += SpecialExample;
        specialAttack.canceled += StopSpecialExample;
    }

    private void OnDisable()
    {
        jump.performed -= JumpExample;

        attack.performed -= AttackExample;
        attack.canceled -= AttackStopExample;

        specialAttack.performed -= SpecialExample;
        specialAttack.canceled -= StopSpecialExample;

        playerNormalActionMap.Disable();
    }


    void Update()
    {
        valueX = move.ReadValue<float>();
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

    private void SpecialExample(InputAction.CallbackContext value)
    {
        Debug.Log("Special Attack");
    }

    private void StopSpecialExample(InputAction.CallbackContext value)
    {
        Debug.Log("Special Attack");
    }
}
