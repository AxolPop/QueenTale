using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class perishing : MonoBehaviour
{
    TextMeshProUGUI deathText;

    // Start is called before the first frame update

    List<string> deathMessageList = new List<string>();

    void Start()
    {
        deathText = GetComponent<TextMeshProUGUI>();

        deathMessageList.Add("perished!");
        deathMessageList.Add("bit the dust!");
        deathMessageList.Add("died!");
        deathMessageList.Add("croaked!");
        deathMessageList.Add("fallen into eternal sleep!");

        int i = Random.Range(1, 100);
        if (i > 80) deathMessageList.Add("been sent to The Forever Box!");

    }

    bool stopUpdate = false;
    string getName;

    string message;

    // Update is called once per frame
    void Update()
    {
        if (troop.displayDeathMessage == true)
        {
            getName = troop.setNameInTextBox;

            if (stopUpdate == false)
            {
                deathText.text = getName + " has " + RandomDeathMessage(message);
                StartCoroutine(BiteZaDusto());
            }
        }
        else { deathText.text = ""; }
    }

    IEnumerator BiteZaDusto()
    {
        stopUpdate = true;
        yield return new WaitForSeconds(3);
        troop.displayDeathMessage = false;
        stopUpdate = false;
    }

    string RandomDeathMessage(string deathMessage)
    {
        int ranNum = Random.Range(1, 5);
        deathMessage = deathMessageList[ranNum];
        Debug.Log(deathMessage);
        return deathMessage;
    }
}
