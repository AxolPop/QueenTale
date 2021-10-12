using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveSlots : MonoBehaviour
{
    public int slot;

    public void save()
    {
        saveSystem.GetSaveSystem.Save(slot);
        objectData.GetObjectData.Save(slot);

        Debug.Log("Saved to slot "+slot);
    }
}
