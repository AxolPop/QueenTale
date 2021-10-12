using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class hideVolume : MonoBehaviour
{
    MotionBlur blur;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Volume>().profile.TryGet<MotionBlur>(out blur))
        {
            blur.active = !screenshotCam.camRenderer;
        }
    }
}
