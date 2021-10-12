using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHole : MonoBehaviour
{

    public int stage;

    public GameObject stageOne;
    public GameObject stageTwo;
    public GameObject stageThree;

    int level;

    bool kill;

    Image healthValue;

    float holeHealth = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        stageOne = transform.Find("Stage 1").gameObject;
        stageTwo = transform.Find("Stage 2").gameObject;
        stageThree = transform.Find("Stage 3").gameObject;

        healthValue = gameObject.transform.Find("Health/Health Value").GetComponent<Image>();

        level = 0;

        switch(stage)
        {
            case 1:
            holeHealth = 1;
            break;

            case 2:
            holeHealth = 0.50f;
            break;

            case 3:
            holeHealth = 0.33f;
            break;
        }
    }

    float totalHoleHealth = 1;

    void Update()
    {
        if (healthValue.fillAmount <= totalHoleHealth)
        {
            totalHoleHealth -= holeHealth;

            if (!kill)
            {
                UpdateStage();
            }
            else
            {

                    stageOne.SetActive(false);
                    stageTwo.SetActive(false);
                    stageThree.SetActive(false);
            }
            
        }
    }

    void UpdateStage()
    {
        level++;

        if (level == stage)
        {
            kill = true;
        }

        if (level == 1)
        {
            stageOne.SetActive(true);
            stageTwo.SetActive(false);
            stageThree.SetActive(false);
        }

        if (level == 2)
        {
            stageOne.SetActive(false);
            stageTwo.SetActive(true);
            stageThree.SetActive(false);
        }

        if (level == 3)
        {
            stageOne.SetActive(false);
            stageTwo.SetActive(false);
            stageThree.SetActive(true);
        }
    }
}
