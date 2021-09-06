using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInteract : MonoBehaviour { public float forceMultiplyer = 1000f, velocity; public Vector3 Velocity;

 private Vector3 lastframepos;
 //checks collision
 private void OnControllerColliderHit(ControllerColliderHit collision)
 {
     //checks if there is rigidbody
     if (collision.rigidbody == null) { return; }
     Vector3 pushDir = Velocity;
     //Adds force to the object
     collision.rigidbody.AddForce(pushDir * velocity * forceMultiplyer * Time.deltaTime, ForceMode.Impulse);
 }
 private void Update()
 {
     //calculates velocity
     Velocity.x = transform.position.x - lastframepos.x;
     Velocity.y = transform.position.x - lastframepos.y;
     Velocity.y = transform.position.y - lastframepos.y;
     //calculates velocity "Speed"
     float vx;
     float vy;
     float vz;
     if(Velocity.x < 0) { vx = Velocity.x * -1; } else { vx = Velocity.x; };
     if (Velocity.y < 0) { vy = Velocity.y * -1; } else { vy = Velocity.y; };
     if (Velocity.z < 0) { vz = Velocity.z * -1; } else { vz = Velocity.z; };
     velocity = vx + vy + vz;
    //Sets the lastframe pos
     lastframepos = transform.position;
 }
}