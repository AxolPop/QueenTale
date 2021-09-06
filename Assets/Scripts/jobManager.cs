using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobManager : MonoBehaviour
{

    //Materials
    [SerializeField] Material farmerMat;
    [SerializeField] Material builderMat;
    [SerializeField] Material minerMat;
    [SerializeField] Material guardMat;


    int troopAddedHealth;

    // Update is called once per frame
    public void setAbilities(GameObject troopObject, string name)
    {
        troop troopScript = troopObject.GetComponent<troop>();
        Renderer troopMaterial = troopScript.troopRenderer;

        switch(name)
        {
            case ("farmer"):
            troopMaterial.material = farmerMat;

            troopScript.canCut = true;
            troopScript.canBuild = false;
            troopScript.canMine = false;
            troopScript.canDig = true;
            troopScript.setDamageSpeed = 1.3f;
            troopAddedHealth = Random.Range(1, 2);
            if (!troopScript.hasIncreasedHealth)
            {
                troopScript.setListHealth(troopScript.maxtroopHealth += troopAddedHealth, troopScript.troopHealth += troopAddedHealth);
                troopScript.hasIncreasedHealth = true;
            }
            break;

            case ("builder"):
            troopMaterial.material = builderMat;

            troopScript.canCut = true;
            troopScript.canBuild = true;
            troopScript.canMine = false;
            troopScript.canDig = true;
            troopScript.setDamageSpeed = 1.3f;
            troopAddedHealth = Random.Range(1, 2);
            if (!troopScript.hasIncreasedHealth)
            {
                troopScript.setListHealth(troopScript.maxtroopHealth += troopAddedHealth, troopScript.troopHealth += troopAddedHealth);
                troopScript.hasIncreasedHealth = true;
            }
            break;

            case ("miner"):
            troopMaterial.material = minerMat;

            troopScript.canCut = true;
            troopScript.canBuild = false;
            troopScript.canMine = true;
            troopScript.canDig = true;
            troopScript.setDamageSpeed = 1.3f;
            troopAddedHealth = Random.Range(2, 3);
            if (!troopScript.hasIncreasedHealth)
            {
                troopScript.setListHealth(troopScript.maxtroopHealth += troopAddedHealth, troopScript.troopHealth += troopAddedHealth);
                troopScript.hasIncreasedHealth = true;
            }
            break;

            case ("guard"):
            troopMaterial.material = guardMat;

            troopScript.canCut = true;
            troopScript.canBuild = false;
            troopScript.canMine = false;
            troopScript.canDig = false;
            troopScript.setDamageSpeed = 0.6f;
            troopAddedHealth = Random.Range(2, 3);
            if (!troopScript.hasIncreasedHealth)
            {
                troopScript.setListHealth(troopScript.maxtroopHealth += troopAddedHealth, troopScript.troopHealth += troopAddedHealth);
                troopScript.hasIncreasedHealth = true;
            }
            break;
        }
    }
}
