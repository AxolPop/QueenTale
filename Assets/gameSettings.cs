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

    Button button;

    public GameObject getPauseMenu;
    public GameObject getReport;
    public GameObject getOptions;
    public GameObject getGameCurrent;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    public void ButtonPressed()
    {
        switch (pauseMenu)
        {
            case pause.resume:
            Time.timeScale = 1;
            system.isPaused = false;
            getPauseMenu.SetActive(false);
            break;

            case pause.options:
            getOptions.SetActive(true);
            getPauseMenu.SetActive(false);
            break;

            case pause.report:
            getReport.SetActive(true);
            // getGameCurrent.SetActive(false);
            getPauseMenu.SetActive(false);
            break;

            case pause.quit:
            Application.Quit();
            break;
        }
    }
}
