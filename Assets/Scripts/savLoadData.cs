using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class savLoadData : MonoBehaviour
{
    void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/projectqueen.savedata"))
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
    }
    public void LoadData()
    {
        if ((Application.persistentDataPath + "/projectqueen.savedata") != null)
        {
            PlayerPrefs.SetInt("loadingData", 1);
            PlayerPrefs.Save();
        }
    }
}
