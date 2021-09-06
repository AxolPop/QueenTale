using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGame : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.GetInt("New Game", 1);
    }
}
