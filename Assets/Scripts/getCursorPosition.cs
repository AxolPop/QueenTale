using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCursorPosition : MonoBehaviour
{
    static public GameObject cursorPositionPosition;

    // Update is called once per frame
    void Update()
    {
        cursorPositionPosition = cursorPosition.cursorObject;
    }
}
