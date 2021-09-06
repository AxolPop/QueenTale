using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSFXVol : MonoBehaviour
{

    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = PlayerPrefs.GetFloat("Sfx Value", 1);
    }
}
