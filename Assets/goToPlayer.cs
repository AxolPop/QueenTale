using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform player;

    Quaternion rotation;

    public GameObject cam;

    // Update is called once per frame

    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, cam.transform.rotation, 5 * Time.deltaTime);
    }
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
