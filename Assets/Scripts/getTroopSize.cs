using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getTroopSize : MonoBehaviour
{
    TextMeshProUGUI pog;
    // Start is called before the first frame update
    void Start()
    {
        pog = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pog.SetText(troop.troopIndex.Count.ToString() + " / " + troop.troopMaxTotal);
    }
}
