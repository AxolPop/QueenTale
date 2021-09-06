using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGlobalName : MonoBehaviour
{
    // Start is called before the first frame update
    InputField field;

    public static string queenName;

    void Start()
    {
        field = GetComponent<InputField>();

        if (PlayerPrefs.HasKey("Queens Name"))
        {
            Debug.Log("yes");
            field.text = PlayerPrefs.GetString("Queens Name");
        }
    }

    // Update is called once per frame
    void Update()
    {
        queenName = field.text;
        PlayerPrefs.SetString("Queens Name", queenName);
    }


    public void SaveData()
    {
        Debug.Log("Why are you not workinggggg aaaaaaaaaaaaaa");
        PlayerPrefs.Save();
    }
}
