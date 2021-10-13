using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum specType
{
    cpu, gpu, provider
}

public class getDeviceSpecs : MonoBehaviour
{
    public static getDeviceSpecs specifications;

    void Awake() {
        specifications = this;
    }

    public specType specTypes;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (specTypes)
        {
            case specType.cpu:
            text.text = "CPU: " + SystemInfo.processorType;
            break;

            case specType.gpu:
            text.text = "GPU: " + SystemInfo.graphicsDeviceName;
            break;

            case specType.provider:
            text.text = "Graphics Provider: " + SystemInfo.graphicsDeviceVendor;
            break;
        }
    }
}
