using UnityEngine;
using TMPro;

public class troopSize : MonoBehaviour
{
    float maxTotal;
    int getTroopIndex;
    public TextMeshProUGUI troopTwotal;


    // Start is called before the first frame update
    void Start()
    {
        maxTotal = troop.troopMaxTotal;
        getTroopIndex = troop.troopIndex.Count;
    }

    // Update is called once per frame
    void Update()
    {
        troopTwotal.SetText(getTroopIndex.ToString() + " / " + maxTotal);

        Debug.Log(troop.troopIndex.Count);
    }
}
