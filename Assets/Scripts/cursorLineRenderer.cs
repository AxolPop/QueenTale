using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorLineRenderer : MonoBehaviour
{

    LineRenderer line;

    public Transform troopOne;

    public Transform cursor;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, new Vector3(cursor.position.x, cursor.position.y, cursor.position.z));
        line.SetPosition(1, new Vector3(troopOne.position.x, troopOne.position.y, troopOne.position.z));

        line.enabled = true;
    }
}
