using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmbeddedSimple : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2D;

    public InputAction moveAction;

    private float direction;

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        direction = moveAction.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(direction * speed, rb2D.velocity.y);
    }
}
