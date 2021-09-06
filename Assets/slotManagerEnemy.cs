using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotManagerEnemy : MonoBehaviour
{
    public enemyWander wander;
    public GameObject getslot;
    public int childCount;
    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponentInParent<enemyWander>();

        childCount = transform.childCount;

        for (int i = 0; i <= childCount; i++)
        {
            getslot = transform.Find("Slot (" + i + ")").gameObject;
            wander.slotList.Add(getslot);
        }
    }
}
