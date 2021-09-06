using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class dialogueText : MonoBehaviour
{

    public List<string> dialogue = new List<string>();

    TextMeshProUGUI text;

    string stringLength;

    string currentText;

    int index;

    IEnumerator startText;

    bool thing = true;

    public float dialogueSpeed = 0.1f;

    string lol;

    string queensName;

    int i;

    int dialogueSkip;
    // Start is called before the first frame update

    troop getTroopScript;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.enabled = false;
        queensName = PlayerPrefs.GetString("Queens Name", "Annette");
        if (queensName == "")
        {
            queensName = "Annette";
        }
        Debug.Log(queensName);
        resetDialogue(); //set dialogue options before calling this
    }

    bool skipText;

    // Update is called once per frame
    void Update()
    {

        if (Gamepad.current != null)
        {
            lol = "<sprite index=11>";
        }
        else
        {
            lol = "<sprite index=16>";
        }

        if (troop.isTalking == true && thing == true)
        {
            
            text.enabled = true;
            getTroopScript = troop.talkingToTroop.GetComponent<troop>();
            index = UnityEngine.Random.Range(0, dialogue.Count);
            stringLength = dialogue[index];
            dialogue.RemoveAt(index);
            startText = dialogueOutput();
            StartCoroutine(startText);
            thing = false;
        }

        if (troop.isTalking == true && !waitingForInput)
        {
            if (Gamepad.current != null)
            {
                if (Gamepad.current.buttonSouth.wasPressedThisFrame && Gamepad.current != null)
                {
                    skipText = true;
                }
            }
            else
            if (Input.GetMouseButtonDown(0) && Gamepad.current == null)
            {
                dialogueSpeed = 0;
            }
        }

        if (dialogue.Count == 0)
        {
            resetDialogue();
        }
    }
    
    public string currentCharacter;

    bool waitingForInput = false;

    bool skipChar = false;

    IEnumerator dialogueOutput()
    {
        dialogueSpeed = 0.02f;

        string fixedString;
        for (i = 0; i < stringLength.Length; i ++)
        {
            currentCharacter = stringLength.Substring(i, 1);

            currentText = stringLength.Substring(0, i);
            text.text = currentText;

            switch (currentCharacter)
            {
                case "#":
                if (!skipText)
                {
                    yield return new WaitForSeconds(0.2f);
                }

                fixedString = stringLength.Remove(i, 1);

                stringLength = fixedString;

                break;

                case "¬":
                waitingForInput = true;
                while (!Input.GetMouseButtonDown(0))
                {
                    yield return null;
                }

                waitingForInput = false;
                fixedString = stringLength.Remove(i, 1);

                stringLength = fixedString;

                break;

                case "¦":
                waitingForInput = true;
                while (!Input.GetMouseButtonDown(0))
                {
                    yield return null;
                }

                fixedString = stringLength.Remove(0, i + 1);

                stringLength = fixedString;

                currentText = "";
                text.text = currentText;

                i = 0;

                waitingForInput = false;

                break;
            }

            yield return new WaitForSeconds(dialogueSpeed);
        }

        yield return new WaitForSeconds(0.2f);

        
        if (Gamepad.current != null)
        {
            while (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame == false)
            {
                yield return null;
            }

            troop.isTalking = false;
            text.enabled = false;
            thing = true;
            skipText = false;
        }
        else
        {
            while (!Input.GetMouseButtonDown(0) && Gamepad.current == null)
            {
                yield return null;
            }

            troop.isTalking = false;
            text.enabled = false;
            thing = true;
            skipText = false;
        }
    }

    void resetDialogue()
    {
        dialogue.Add("So, " + queensName + "!# Do you enjoy the carefree lounging about? Like sitting, lying down, generally doing nothing? ¦You should give those slackers jobs,# maybe then they think twice about sitting down in front of your presence! ¦Huh? What about me?# Maybe i'm the one lounging about.#.#.# ¦I don't really know!# All I care about is serving you, my queen...!# ¦U#-unlike those dumb slackers, amirite? ");
        dialogue.Add("I hate guards,# they always talk about 'protecting us' when they do jack! ¦I demand to see a lawyer,# a manager,# anyone that has some kind of ruling over this darned Kingdom! ¦It's not like those guards protect us when those Bunbees come into the kingdom,# right? ¦ R#-right??? ");
        dialogue.Add("im funny jaja, ¦its funny because im not happy.#.#.# haha.#.#.# ");
    }
}
