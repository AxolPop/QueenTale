using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Canvas>().enabled = !screenshotCam.camRenderer;
    }
}
