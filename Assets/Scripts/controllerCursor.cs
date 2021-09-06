using UnityEngine;
using UnityEngine.InputSystem;

public class controllerCursor : MonoBehaviour
{
    public GameObject player;

    //Controller Setup
    GameControls controller;
    CharacterController cc;
    Vector2 move;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null)
        {
            Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;
    
            if (direction.magnitude >= 0.1f && troop.isTalking == false)
            {
    
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
    
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            }
        }
    }
}

