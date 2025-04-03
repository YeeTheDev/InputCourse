using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvokeCanvasEvent : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private GameObject canvas;

    private Vector2 direction;

    private InputActionMap playerBasic;
    private InputActionMap mapUI;
    private InputActionMap mapSwitcher;

    private InputAction attackAction;
    private InputAction moveAction;
    private InputAction menuActivateDeactivate;

    private void OnEnable()
    {
        playerBasic = playerInput.actions.FindActionMap("PlayerBasic");
        mapUI = playerInput.actions.FindActionMap("UI");
        mapSwitcher = playerInput.actions.FindActionMap("MapSwitcher");

        mapUI.Disable();

        attackAction = playerBasic.FindAction("Attack");
        moveAction = playerBasic.FindAction("Move");
        menuActivateDeactivate = mapSwitcher.FindAction("Menu");

        attackAction.performed += AttackExample;
        menuActivateDeactivate.performed += MenuControl;

        playerBasic.Enable();
        mapSwitcher.Enable();
    }

    private void OnDisable()
    {
        attackAction.performed -= AttackExample;
        menuActivateDeactivate.performed -= MenuControl;
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
        InputActionMap currentMap = playerInput.currentActionMap;

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

    InputActionMap placeHolderActionMap;

    private void MenuControl(InputAction.CallbackContext value)
    {
        if (canvas == null) { return; }

        if (placeHolderActionMap == null)
        {
            placeHolderActionMap = playerInput.currentActionMap;
        }

        if (!canvas.activeSelf)
        {
            canvas.SetActive(true);
            playerInput.SwitchCurrentActionMap(mapUI.name);
        }
        else
        {
            canvas.SetActive(false);
            playerInput.SwitchCurrentActionMap(placeHolderActionMap.name);
            placeHolderActionMap = null;
        }
    }
}
