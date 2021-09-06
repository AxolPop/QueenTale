using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemySign : MonoBehaviour
{
    enemyWander getHealth;

    public static bool failsafe;

    public UnityEvent whatHappensWhenBuildingStarts;
    public UnityEvent whatHappensWhenBuildingFinished;

    public GameObject failsafePosition;

    bool lockBool = false;

    void Awake()
    {
        getHealth = GetComponent<enemyWander>();

    }

    // Update is called once per frame
    void Update()
    {
        //Saving and Loading Failsafe, make sure to enable stairs, but disable the NavMeshObstacle :flushed:
        if (getHealth.health < 1 && !lockBool)
        {
            lockBool = true;

            whatHappensWhenBuildingStarts.Invoke();

            whatHappensWhenBuildingFinished.Invoke();
        }
        else if (!lockBool && getHealth.health < getHealth.maxHealth)
        {
            StartCoroutine(BuildingStages());
        }
    }

    IEnumerator BuildingStages()
    {
        lockBool = true;

        whatHappensWhenBuildingStarts.Invoke();

        while (getHealth.health > 1)
        {
            yield return null;
        }

        whatHappensWhenBuildingFinished.Invoke();
    }
}
