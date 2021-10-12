using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class saveSlots1 : MonoBehaviour
{
    public int slot;

    Text slotEmptyOrNot;

    private void Start()
    {
        slotEmptyOrNot = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (File.Exists(saveSystem.saveLocation(slot)))
        {
            slotEmptyOrNot.text = "Load Slot " + (slot + 1);
        }
        else
        {
            slotEmptyOrNot.text = "New Game";
        }
    }

    public void load()
    {
        if (File.Exists(saveSystem.saveLocation(slot)))
        {
            PlayerPrefs.SetInt("loadingData", slot + 1);
            SceneManager.LoadScene(1);
            Debug.Log("Loaded Slot"+slot);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
