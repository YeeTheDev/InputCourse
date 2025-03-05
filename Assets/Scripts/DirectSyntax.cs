using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectSyntax : MonoBehaviour
{


    void Update()
    {
        Keyboard myKeyboard = Keyboard.current;
        Gamepad myGamepad = Gamepad.current;

        if (myKeyboard != null)
        {
            if (myKeyboard.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("Spacekey was pressed this frame");
            }

            if (myKeyboard.spaceKey.wasReleasedThisFrame)
            {
                Debug.Log("Spacekey was released this frame");
            }
            if (myKeyboard.spaceKey.isPressed)
            {
                Debug.Log("Spacekey is pressed");
            }
        }
        if (myGamepad != null)
        {
            if (myGamepad.buttonWest.wasPressedThisFrame)
            {
                Debug.Log("Button West was pressed this frame");
            }
            if (myGamepad.dpad.left.wasPressedThisFrame)
            {
                Debug.Log("Dpag Left was pressed this frame");
            }

            Debug.Log(myGamepad.leftStick.ReadValue());
        }
    }
}
