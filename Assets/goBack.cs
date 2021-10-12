using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBack : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject getParent;
    public GameObject getPause;

    public void Butt()
    {
        getPause.SetActive(true);
        getParent.SetActive(false);
    }
}
