using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class talkLol : MonoBehaviour
{
    TextMeshProUGUI text;

    string stringlol;

    public string troopName;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
        troopName = transform.root.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "sign")
        {
            stringlol = "Read";
        }
        else
        {
            stringlol = "Talk to";
        }

        if (Gamepad.current != null)
        {
            text.text = "<sprite index=10>: " + stringlol + " " + troopName;
        }
        else
        {
            text.text = "[F]: " + stringlol + " " + troopName;
            text.ForceMeshUpdate();
        }
    }
}
