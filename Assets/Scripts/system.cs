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

    public GameObject pauseMenu;
    public GameObject options;
    public GameObject report;
    public static bool isPaused;
    public bool isPaused_;

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true; 

        isPaused_ = isPaused;

        if (isPaused && Input.GetKeyDown(KeyCode.Escape) && SystemInfo.deviceType == DeviceType.Desktop)
        {
            Debug.Log("Pause");
            pauseMenu.SetActive(false);
            options.SetActive(false);
            report.SetActive(false);

            Time.timeScale = 1;

            isPaused = false;
        }
        else if (!isPaused && Input.GetKeyDown(KeyCode.Escape) && SystemInfo.deviceType == DeviceType.Desktop)
        {
            pauseMenu.SetActive(true);

            Time.timeScale = 0;

            isPaused = true;
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
