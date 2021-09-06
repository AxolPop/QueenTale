using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMusLol : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = PlayerPrefs.GetFloat("Mus Value", 1);
    }
}
