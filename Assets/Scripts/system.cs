using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager

public class system : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;      
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true; 
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SystemInfo.deviceType == DeviceType.Desktop)
        {
            Application.Quit();
        }

        if (Application.isEditor && Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Time.timeScale += 3f;
        }

        if (Application.isEditor && Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Time.timeScale -= 3f;
        }
    }
}
