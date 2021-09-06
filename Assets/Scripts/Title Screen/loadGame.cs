using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour
{
    void Start()
    {
        Screen.fullScreen = true;
    }

    public void PlayGame()
    {
        Debug.Log("Scene trying to be loaded");
        SceneManager.LoadScene("SampleScene");
    }
}
