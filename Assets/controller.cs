using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller : MonoBehaviour
{
    public static bool onController;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            onController = false;
        }

        if (Gamepad.current != null && Gamepad.current.IsPressed(1))
        {
            onController = true;
        }
    }
}
