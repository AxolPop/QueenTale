using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class troopHealthNum : MonoBehaviour
{
    Text healthNum;
    troop troopHealthBro;

    // Start is called before the first frame update
    void Start()
    {
        healthNum = gameObject.GetComponent<Text>();
        troopHealthBro = transform.parent.parent.Find("Health").GetComponentInParent<troop>();
    }

    // Update is called once per frame
    void Update()
    {
        healthNum.text = troopHealthBro.troopHealth.ToString();
    }
}
