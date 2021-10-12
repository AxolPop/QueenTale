using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using WindowsInput;

public class controller : MonoBehaviour
{
    InputSimulator inputSimulator;

    void Start()
    {
        inputSimulator = new InputSimulator();
    }
    public static bool onController;
    // Update is called once per frame
    void Update()
    {
        //if (!Application.isFocused)
        //return();

        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonSouth.wasPressedThisFrame || Gamepad.current.rightTrigger.wasPressedThisFrame)
            {
                inputSimulator.Mouse.LeftButtonClick();
            }

            if (Gamepad.current.buttonWest.wasPressedThisFrame || Gamepad.current.leftTrigger.wasPressedThisFrame)
            {
                inputSimulator.Mouse.RightButtonClick();
            }

            if (Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_F);
            }
            
            if (Gamepad.current.leftShoulder.IsPressed())
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_Q);
            }

            if (Gamepad.current.rightShoulder.IsPressed())
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_E);
            }

            if (Gamepad.current.dpad.up.wasPressedThisFrame)
            {
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LCONTROL);
            }

            if (Gamepad.current.dpad.right.wasPressedThisFrame)
            {
                inputSimulator.Mouse.VerticalScroll(1);
            }

            if (Gamepad.current.dpad.left.wasPressedThisFrame)
            {
                inputSimulator.Mouse.VerticalScroll(-1);
            }
        }
    }
}
