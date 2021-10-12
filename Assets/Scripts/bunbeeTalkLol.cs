using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunbeeTalkLol : MonoBehaviour
{

    enemyWander enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<enemyWander>();
    }

    LayerMask mask = 1 << 19;

    Collider[] hitColliders;

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.state == enemyWander.State.wandering)
        {
            hitColliders = Physics.OverlapSphere(transform.position, 3, mask);

            if (hitColliders.Length > 0)
            {
                foreach (var hitCollider in hitColliders)
                {
                    enemyScript.ai.SetDestination(hitCollider.gameObject.transform.position);
                }
            }
        }
    }
}
