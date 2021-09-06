using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troopCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (troop.troopIndex.Count > 0 && playerMovement.isInDoor == false)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else { GetComponent<Renderer>().enabled = false; }

        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }
}
