using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troopJump : MonoBehaviour
{

    public GameObject target;

    public Transform targetPosition;

    GameObject troopAi;

    troop troopScript;

    enemyWander enemyScr;

    Collider[] hitColliders;

    LayerMask mask = 1 << 11;

    // Update is called once per frame
    void Update()
    {
        hitColliders = Physics.OverlapSphere(transform.position, 2.5f, mask);

        if (hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                troopAi = hitCollider.gameObject;
                troopScript = troopAi.GetComponent<troop>();
                if (troopScript.state == troop.State.charging)
                {
                    troopScript.lolTarget = targetPosition;
                    troopScript.state = troop.State.jumping;
                }
            }
        }
    }
}
