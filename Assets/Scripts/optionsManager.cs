using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class optionsManager : MonoBehaviour
{

    public Slider volumeSlider;
    public Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Mus Value", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("Sfx Value", 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Sfx Value", sfxSlider.value);
        PlayerPrefs.SetFloat("Mus Value", volumeSlider.value);
    }

    public void saveOptions()
    {
        PlayerPrefs.Save();
    }
}
