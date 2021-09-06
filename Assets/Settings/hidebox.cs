using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class hidebox : MonoBehaviour
{
    public Image image;
    public List<Sprite> myTextures = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null)
        {
            image.sprite = myTextures[0];
        }
        else
        {
            image.sprite = myTextures[1];
        }

        if (troop.isTalking == true)
        {
            image.enabled = true;
        }
        else { image.enabled = false; }
    }
}
