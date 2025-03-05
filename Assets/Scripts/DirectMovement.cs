using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2D;

    private float valueX, valueY;
    private Vector2 direction;
    private Vector2 directionGamepad;

    void Update()
    {
        Keyboard myKeyboard = Keyboard.current;
        Gamepad myGamepad = Gamepad.current;

        valueX = 0; valueY = 0;
        if (myKeyboard != null)
        {
            if (myKeyboard.aKey.isPressed) { valueX += -1; }
            if (myKeyboard.dKey.isPressed) { valueX += 1; }
            if (myKeyboard.sKey.isPressed) { valueY += -1; }
            if (myKeyboard.wKey.isPressed) { valueY += 1; }
        }

        if (myGamepad != null)
        {
            directionGamepad = myGamepad.leftStick.ReadValue();
            valueX = directionGamepad.x;
            valueY = directionGamepad.y;
        }

        direction = new Vector2(valueX, valueY).normalized;
    }

    private void FixedUpdate()
    {
        rb2D.velocity = direction * speed;
    }
}
