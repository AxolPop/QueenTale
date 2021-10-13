using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameSettings : MonoBehaviour
{
    public static gameSettings pauseMenu_;

    void Awake()
    {
        pauseMenu_ = this;
    }

    public enum pause
    {
        resume, options, report, quit
    }

    public pause pauseMenu;

    public void ButtonPressed()
    {
        switch (pauseMenu)
        {
            case pause.quit:
            Application.Quit();
            break;

            case pause.resume:
            Time.timeScale = 1;

            system.isPaused = false;
            break;
        }
    }
}
