using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotManager : MonoBehaviour
{
    public List<GameObject> slotPrivate = new List<GameObject>();
    public static List<GameObject> slots = new List<GameObject>();

    public List<int> troops = new List<int>();

    GameObject slot_;

    // Update is called once per frame

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            slot_ = GameObject.Find("slot (" + i.ToString() + ")");

            slotPrivate.Add(slot_);
        }

        troops = troop.troopIndex;
    }
    void Update()
    {
        slots = slotPrivate;
        troops = troop.troopIndex;
    }
}
