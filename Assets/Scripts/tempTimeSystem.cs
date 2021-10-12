using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG;

public class tempTimeSystem : MonoBehaviour
{
    public GameObject clockHandle;

    AudioSource source;

    public AudioClip clip;

    public Color[] colorSet;

    public Light dirlight;

    int infiniteNum;


    float num;

    float timer = 0;

    public int timeStep = 120;

    public int setTimeStep;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        num = setTimeStep;
        infiniteNum = 10;
        StartCoroutine(TimeStep());
    }

    public int colorGet = 1;

    public void LoadTime(Vector3 direction)
    {
        DOTween.KillAll();

        dirlight.DOColor(colorSet[colorGet - 1], 0);

        clockHandle.transform.eulerAngles = direction;

        clockHandle.transform.DORotate(new Vector3(0, 0, timestepClock), 120).SetEase(Ease.Linear);
    }

    IEnumerator TimeStep()
    {

        while (1 < infiniteNum)
        {
            if (timeStep % 120 == 0)
            {
                source.PlayOneShot(source.clip);

                timestepClock -= 30;

                clockHandle.transform.DORotate(new Vector3(0, 0, timestepClock), 120).SetEase(Ease.Linear);
                

                if (timestepClock < -360)
                {
                    clockHandle.transform.eulerAngles = new Vector3(0, 0, 0);
                    timestepClock = -30;
                }
            }

            if (timeStep % 90 == 0)
            {

                Debug.Log("Time change");

                if (colorGet == colorSet.Length)
                {
                    colorGet = 0;
                }

                Debug.Log("Time change??");

                switch (timeStep)
                {
                    case (270):
                    dirlight.DOColor(colorSet[colorGet], 50);
                    colorGet++;
                    break;
                    case (360):
                    dirlight.DOColor(colorSet[colorGet], 50);
                    colorGet++;
                    break;
                    case (900):
                    dirlight.DOColor(colorSet[colorGet], 50);
                    colorGet++;
                    break;
                    case (990):
                    dirlight.DOColor(colorSet[colorGet], 50);
                    colorGet++;
                    break;
                }

                num += setTimeStep;
            }

            timeStep++;

            yield return new WaitForSeconds(1);
        }
    }

    public int timestepClock = -180;
}
