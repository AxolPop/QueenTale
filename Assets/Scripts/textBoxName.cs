using UnityEngine;
using UnityEngine.UI;


public class textBoxName : MonoBehaviour
{
     Text text;

    void Start() 
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (troop.isTalking == true)
        {
            text.enabled = true;
            text.text = troop.setNameInTextBox;
        }
        else
        {
            text.enabled = false;
        }
    }
}