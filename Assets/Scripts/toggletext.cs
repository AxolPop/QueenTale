using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toggletext : MonoBehaviour
{
    TextMeshProUGUI image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<TextMeshProUGUI>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            image.enabled = !image.enabled;
        }
    }
}
