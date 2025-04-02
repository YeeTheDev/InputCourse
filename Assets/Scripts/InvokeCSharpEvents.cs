using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvokeCSharpEvents : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;

    private InputAction attackAction;
    private InputActionMap playerBasic;
    private InputAction moveAction;

    private void OnEnable()
    {
        //Use this to Switch between action maps, this enables and disables automatically.
        //playerInput.SwitchCurrentActionMap("PlayerBasic");

        playerBasic = playerInput.actions.FindActionMap("PlayerBasic");
        //attackAction = playerInput.actions.FindAction("Attack");
        attackAction = playerBasic.FindAction("Attack");
        moveAction = playerBasic.FindAction("Move");

        attackAction.performed += AttackExample;
        playerBasic.Enable();
    }

    private void OnDisable()
    {
        attackAction.performed -= AttackExample;

        playerBasic.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("ValueY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        if (direction != Vector2.zero)
        {
            animator.SetFloat("ValueX", direction.x);
            animator.SetFloat("ValueY", direction.y);
            animator.SetBool("IsMoving", true);
        }
        else { animator.SetBool("IsMoving", false); }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void AttackExample(InputAction.CallbackContext value)
    {
        Debug.Log("Attack Example");
    }
}
