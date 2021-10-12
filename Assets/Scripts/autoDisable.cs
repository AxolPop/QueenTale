using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDisable : MonoBehaviour
{
    public bool isBridge;

    MeshCollider collider_;
    MeshRenderer renderer_;
    // Start is called before the first frame update
    void Start()
    {
        if (!isBridge)
        {
            collider_ = GetComponent<MeshCollider>();
        }
        renderer_ = GetComponent<MeshRenderer>();

        if (!isBridge)
        {
            collider_.enabled = false;
        }
        renderer_.enabled = false;
    }
}
