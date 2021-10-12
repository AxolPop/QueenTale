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

    public GameObject controllerCursor_;

    Vector3 dir;

    RaycastHit hit2;

    void Start()
    {
        cursorObject = gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (!system.isPaused)
        {
            cursorObject = gameObject;

            dir = controllerCursor_.transform.position - Camera.main.transform.position;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (controllerCursor.controllerEnabled)
            {
                if (Physics.Raycast(Camera.main.transform.position, dir, out hit2, 100, mask) && !snapToPosition)
                {
                    transform.position = hit2.point;
                }
            }
            else
            if (Physics.Raycast(ray, out hit, 100, mask) && !snapToPosition)
            {
                transform.position = hit.point;
            }
            else if (snapToPosition)
            {

            }

            if (controllerCursor.controllerEnabled)
            {
                rotation = Quaternion.FromToRotation(-transform.forward, hit2.normal) * transform.rotation;
            }
            else
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
    }

    public void canSnap(GameObject enemy)
    {
        enemyLol = enemy;
    }
}

