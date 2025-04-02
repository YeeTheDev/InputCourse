using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputInvokeUnityEvents : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    public void MoveExample(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }

    public void AttackExample(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Started");
        }
        if (value.performed)
        {
            Debug.Log("Performed");
        }
        if (value.canceled)
        {
            Debug.Log("Canceled");
        }
    }
}
