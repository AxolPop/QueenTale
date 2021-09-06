using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTroop : MonoBehaviour
{
    Vector3 spawnLocation;
    public Transform location;
    public int spawnLimit;
    public GameObject troopObject;

    [SerializeField] GameObject setManager;

    public static int instantateID;

    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = location.transform.position;
        rotation = location.transform.rotation;
        
        for (int i = 0; i <= spawnLimit; i++)
        {
            if (troopObject != null)
            {
                instantateID = i;       
                var newTroop = Instantiate(troopObject, spawnLocation, rotation);
            }
        }

        troop.troopSpawnID.Remove(troopObject);

        Destroy(troopObject);
    }
}
