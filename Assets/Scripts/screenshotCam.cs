 using UnityEngine;
 
 public class screenshotCam : MonoBehaviour
 {
     public static screenshotCam Instance;
     [SerializeField] float speed = 0.5f;
     [SerializeField] float sensitivity = 1.0f;
 
     Camera cam;
     Vector3 anchorPoint;
     Quaternion anchorRot;

     public static bool camRenderer;
 
     private void Awake()
     {
         Instance = this;
         cam = GetComponent<Camera>();
     }

     void Update()
     {
         if (Input.GetKeyDown(KeyCode.Keypad7) && Application.isEditor)
         {
             camRenderer = !camRenderer;
         }

            cam.enabled = camRenderer;
            
     }
     
     void FixedUpdate()
     {
         if (camRenderer)
         {
             Vector3 move = Vector3.zero;
         if(Input.GetKey(KeyCode.U))
             move += Vector3.forward * speed;
         if (Input.GetKey(KeyCode.J))
             move -= Vector3.forward * speed;
         if (Input.GetKey(KeyCode.K))
             move += Vector3.right * speed;
         if (Input.GetKey(KeyCode.H))
             move -= Vector3.right * speed;
         if (Input.GetKey(KeyCode.E))
             move += Vector3.up * speed;
         if (Input.GetKey(KeyCode.Q))
             move -= Vector3.up * speed;
         transform.Translate(move);
 
         if (Input.GetMouseButtonDown(1))
         {
             anchorPoint = new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
             anchorRot = transform.rotation;
         }
         if (Input.GetMouseButton(1))
         {
             Quaternion rot = anchorRot;
             Vector3 dif = anchorPoint - new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
             rot.eulerAngles += dif * sensitivity;
             transform.rotation = rot;
         }
         }
     }
 }