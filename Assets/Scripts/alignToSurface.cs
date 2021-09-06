using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alignToSurface : MonoBehaviour
{
    RaycastHit hit;

    LayerMask mask = 1 << 8;

    Ray ray;

    Vector3 dir;

    Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(transform.position.x, 1000, transform.position.z);

        if (Physics.Raycast(dir, transform.TransformDirection(Vector3.down), out hit, 1010, mask))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 12.69f, transform.position.z);
        }
    }
}
