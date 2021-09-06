using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class faceDirection : MonoBehaviour
{
    public GameObject cursorPosition;
    public Transform player;

    bool cursorOn = false;

    public GameObject active;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
        if (Gamepad.current == null)
        {
            
            Vector3 setRotation = new Vector3(cursorPosition.transform.position.x, gameObject.transform.position.y, cursorPosition.transform.position.z) ;

            gameObject.transform.LookAt(setRotation);
        }

        Cursor.visible = false;
    }
}
