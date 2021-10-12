using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotManagerEnemy : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 direction;
    public float playerPos;
    public enemyWander wander;
    public GameObject getslot;
    public GameObject getslot2;
    public int childCount;
    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponentInParent<enemyWander>();

        childCount = transform.childCount;

        for (int i = 0; i <= childCount - 1; i++)
        {
            getslot = transform.Find("Slot (" + i + ")").gameObject;
            wander.slotList.Add(getslot);

            // getslot2 = transform.Find("JSlot (" + i + ")").gameObject;
            // wander.jumpSlotList.Add(getslot2);
        }
    }

    private void Update()
    {
        direction = transform.TransformDirection(transform.forward);

        if (playerMovement.player_ != null)
        offset = playerMovement.player_.gameObject.transform.position - gameObject.transform.position;

        playerPos = System.Math.Sign(Vector3.Dot(offset, direction));

        if (playerPos < 0)
        {
            transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (playerPos > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
