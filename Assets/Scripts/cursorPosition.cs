using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class cursorPosition : MonoBehaviour
{

    static public GameObject cursorObject;
    public RaycastHit hit;

    Ray ray;

    LayerMask mask = 1 << 8;
    
    public int speed;
    Quaternion rotation;

    public bool snapToPosition = false;

    GameObject enemyLol;

    void Start()
    {
        cursorObject = gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        cursorObject = gameObject;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
        if (Physics.Raycast(ray, out hit, 100, mask) && !snapToPosition)
        {
            transform.position = hit.point;
        }
        else if (snapToPosition)
        {

        }


        rotation = Quaternion.FromToRotation(-transform.forward, hit.normal) * transform.rotation;

        transform.rotation = rotation;

        transform.Rotate(0, 0, 2 * speed * Time.deltaTime);

        if (snapToPosition)
        {
            transform.position = new Vector3(enemyLol.transform.position.x, transform.position.y, enemyLol.transform.position.z);
            transform.localRotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z * rotation.z);
        }

        //transform.Rotate(0, 0, 5 * speed * Time.deltaTime); //owow

        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonSouth.wasPressedThisFrame || Gamepad.current.rightTrigger.wasPressedThisFrame)
            {
                speed = 300;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            speed = 300;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            speed = -400;
        }

        if (speed > 50)
        {
            speed -= 5;
        }
        else if (speed < 50)
        {
            speed += 5;
        }
        else {speed = 50;}
    }

    public void canSnap(GameObject enemy)
    {
        enemyLol = enemy;
    }
}

