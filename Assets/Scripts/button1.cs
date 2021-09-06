using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class button1 : MonoBehaviour
{
    public UnityEvent Event;

    public float triggerSize;

    // Update is called once per frame

    LayerMask mask = 1 << 9;

    RaycastHit hit;
    void Update()
    {
        if (Physics.CheckSphere(gameObject.transform.position, triggerSize, mask))
        {
            PlayerPrefs.DeleteKey(gameObject + "buttonPressed");
            PlayerPrefs.SetInt(gameObject.name + "buttonPressed", 1);
            PlayerPrefs.Save();
            Event.Invoke();
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("New Game") == 1)
        {
            if (PlayerPrefs.HasKey(gameObject.name + "buttonPressed"))
            {
                PlayerPrefs.DeleteKey(gameObject.name + "buttonPressed");
            }
        }

        if (PlayerPrefs.GetInt("loadingData") == 1)
        {
            if (PlayerPrefs.GetInt(gameObject.name + "buttonPressed") == 1)
            {
                Event.Invoke();
            }
        }
        else
        {
            PlayerPrefs.DeleteKey(gameObject + "buttonPressed");
        }
    }
}
