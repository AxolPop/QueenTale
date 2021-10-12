using UnityEngine;
using UnityEngine.InputSystem;

public class controllerCursor : MonoBehaviour
{
    public GameObject player;
    public static bool controllerEnabled;

    //Controller Setup
    public GameControls controller;
    CharacterController cc;
    Vector2 move;

    public float speed;

    float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    private void OnEnable()
    {
        controller.Enable();
    }

    Vector3 newPos;

    private void OnDisable()
    {
        controller.Disable();
    }

    Quaternion rotation;

    public Transform cam;

    void Awake()
    {
        rotation = transform.rotation;
        controller = new GameControls();

        controller.MainControls.RightStickMove.performed += ctx => move = ctx.ReadValue<Vector2>();
        controller.MainControls.RightStickMove.canceled += ctx => move = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (direction2.magnitude != 0)
        {
            Ray worldSpace = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = 1 << 8;
            

            if (Physics.Raycast(worldSpace, out hit, 100, mask))
            {
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }

        if (Gamepad.current != null && direction2.magnitude == 0)
        {
            controllerEnabled = true;

            Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;
    
            if (direction.magnitude >= 0.1f && troop.isTalking == false)
            {
    
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
    
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                cc.Move(new Vector3(moveDir.normalized.x, 0, moveDir.normalized.z) * speed * Time.deltaTime);
            }
        }
        else {controllerEnabled = false;}
    }
}

