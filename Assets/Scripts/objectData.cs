using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class objectData : MonoBehaviour
{
    public static objectData GetObjectData;

    private void Awake() {
        GetObjectData = this;
    }

    public List<GameObject> destroyedObstacles = new List<GameObject>();

    public List<getObjectData> saveList = new List<getObjectData>();

    [Serializable]
    public class getObjectData
    {
        public GameObject obstacle;
    }

    int i;

    getObjectData saveData = new getObjectData();

    string saveDataSet;

    string savepath;

    public tempTimeSystem saveTime;

    public static string saveLocation(int saveSlot)
    {
        return Application.persistentDataPath + "/obstacle" + saveSlot + ".data";
    }
    
    public void Save(int loc)
    {
        saveList = new List<getObjectData>();

        for (int i = 0; i < destroyedObstacles.Count; i++)
        {
            saveData = new getObjectData();

            saveData.obstacle = destroyedObstacles[i];

            saveList.Add(saveData);
        }

        saveDataSet = JsonHelper.ToJson(saveList.ToArray());

        string output = Rot39(saveDataSet.ToString());

        File.WriteAllText(saveLocation(loc), output);
    }

    public List<getObjectData> loadList;

    enemyWander obstacles;

    public void Load(int num)
    {
        string readFromData = File.ReadAllText(saveLocation(num));

        string output = Rot39(readFromData);

        //Load as Array
        getObjectData[] _tempLoadListData = JsonHelper.FromJson<getObjectData>(output);
        //Convert to List
        loadList = _tempLoadListData.OfType<getObjectData>().ToList();


        for (int i = 0; i < loadList.Count; i++)
        {
            obstacles = loadList[i].obstacle.GetComponent<enemyWander>();

            obstacles.remove();
        }
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Load(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Load(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
           Load(2);
        }
    }

    string Rot39(string input)
    {
        // This string contains 78 different characters in random order.
        var mix = "QDXkW<_(V?cqK.lJ>-*y&zv9prf8biYCFeMxBm6ZnG3H4OuS1UaI5TwtoA#Rs!,7d2@L^gNhj)EP$0";
        var result = (input ?? "").ToCharArray();
        for (int i = 0; i < result.Length; ++i)
        {
            int j = mix.IndexOf(result[i]);
            result[i] = (j < 0) ? result[i] : mix[(j + 39) % 78];
        }
        return new string(result);
    }
}
