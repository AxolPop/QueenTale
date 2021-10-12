using UnityEngine;

public class keypadNums : MonoBehaviour
{
    public static keypadNums nums;

    public int numPressed;
    public bool keyIsPressed;
    void Awake() {
        nums = this;
    }
    void Update() {

        if (Input.GetKey(KeyCode.Keypad0))
        {
            numPressed = 0;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            numPressed = 1;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        
        if (Input.GetKey(KeyCode.Keypad2))
        {
            numPressed = 2;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            numPressed = 3;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            numPressed = 4;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            numPressed = 5;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            numPressed = 6;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad7))
        {
            numPressed = 7;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            numPressed = 8;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
        if (Input.GetKey(KeyCode.Keypad9))
        {
            numPressed = 9;
            keyIsPressed = true;
        }
        else
        {
            keyIsPressed = false;
            numPressed = -1;
        }
    }

}