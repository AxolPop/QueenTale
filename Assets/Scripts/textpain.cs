using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textpain : MonoBehaviour
{
    public Text troopTwotal;
    // Start is called before the first frame update
    void Start()
    {
        troopTwotal.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        troopTwotal.text = playerMovement.inAttackArea.ToString();
        troopTwotal.SetAllDirty();
    }
}
