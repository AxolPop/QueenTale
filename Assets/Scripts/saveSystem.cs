using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class saveSystem : MonoBehaviour
{
    void Awake()
    {
        savepath = Application.persistentDataPath + "/projectqueen.savedata";
    }

    GameObject troopData;
    troop scriptLol;
    cameraMovement cameraScript;

    public GameObject player;

    public List<troopData_> saveList = new List<troopData_>();

    [Serializable]
    public class troopData_
    {

        public float cameraX;

        //Troops
        public Vector3 troopPosition;
        public Vector3 troopBeforeJump;
        public float troopHealth;
        public int maxTroopHealth;
        public string troopName;
        public string troopState;
        public string troopJob;
        public List<int> lolTroopIndex;
        public int getTroopIndex;
        public bool increasedHealth;

        //Player
        public Vector3 playerPosition;
        public float playerHealth;

        //Obstacles
        public bool isObstacleDead;

        //Time
        public int timeStep_;
        public int colorGet_;
        public int timestepClock_;
        public Vector3 handRotation;
    }

    int i;

    troopData_ saveData = new troopData_();

    string saveDataSet;

    string savepath;

    public tempTimeSystem saveTime;
    
    public IEnumerator Save()
    {
        enemySave();

        Debug.Log("Saving Data...");
        saveList = new List<troopData_>();

        for (i = 0; i < troop.troopSpawnID.Count; i++)
        {
            saveData = new troopData_();
            troopData = troop.troopSpawnID[i];
            scriptLol = troopData.GetComponent<troop>();
            cameraScript = Camera.main.GetComponent<cameraMovement>();

            if (cameraScript == null)
            {
                Debug.LogError("Was not able to save camera position");
            }

            saveData.cameraX = cameraScript.transposer.m_XAxis.Value;
                        
            saveData.playerPosition = player.transform.position;
            saveData.playerHealth = playerMovement.playerHealth;

            saveData.lolTroopIndex = troop.troopIndex;
            saveData.troopHealth = scriptLol.troopHealth;
            saveData.maxTroopHealth = scriptLol.maxtroopHealth;
            saveData.troopName = scriptLol.name;
            saveData.troopPosition = troopData.transform.position;
            saveData.troopBeforeJump = scriptLol.beforeJumpPosition;
            saveData.troopState = scriptLol.stateText;
            saveData.troopJob = scriptLol.job;
            saveData.getTroopIndex = scriptLol.troopGetIndex;

            saveData.increasedHealth = scriptLol.hasIncreasedHealth;

            saveData.timeStep_ = saveTime.timeStep;
            saveData.timestepClock_ = saveTime.timestepClock;
            saveData.colorGet_ = saveTime.colorGet;
            saveData.handRotation = saveTime.clockHandle.transform.eulerAngles;

            saveList.Add(saveData);
        }

        saveDataSet = JsonHelper.ToJson(saveList.ToArray());

        string output = Rot39(saveDataSet.ToString());

        File.WriteAllText(savepath, output);

        Debug.Log("Data Successfully Saved!");

        yield return null;
    }

    public List<troopData_> loadList;

    public void Load()
    {
        PlayerPrefs.DeleteKey("loadingData");

        enemyLoad();

        string readFromData = File.ReadAllText(savepath);

        string output = Rot39(readFromData);

        //Load as Array
        troopData_[] _tempLoadListData = JsonHelper.FromJson<troopData_>(output);
        //Convert to List
        loadList = _tempLoadListData.OfType<troopData_>().ToList();

        for (int i = 0; i < loadList.Count; i++)
        {
            var recieveData = loadList[i];

            troopData = troop.troopSpawnID[i];
            scriptLol = troopData.GetComponent<troop>();

            if (troop.troopIndex.Count > 0)
            {
                scriptLol.ClearTroops();
            }

            troopData.name = recieveData.troopName;
            scriptLol.setListHealth(recieveData.maxTroopHealth, recieveData.troopHealth);
            scriptLol.ai.Warp(recieveData.troopPosition);
            scriptLol.hasIncreasedHealth = recieveData.increasedHealth;
            scriptLol.setJobOnLoad(recieveData.troopJob);

            troop.troopIndex = loadList[0].lolTroopIndex;

            switch (recieveData.troopState)
            {
                case "atKing":
                scriptLol.state = troop.State.atKing;
                break;

                case "charging":
                scriptLol.state = troop.State.charging;
                scriptLol.StartCoroutine(scriptLol.returnToPlayer());
                break;

                case "attacking":
                scriptLol.state = troop.State.charging;
                scriptLol.StartCoroutine(scriptLol.returnToPlayer());
                break;

                case "jumping":
                scriptLol.ai.Warp(recieveData.troopBeforeJump);
                scriptLol.state = troop.State.charging;
                scriptLol.StartCoroutine(scriptLol.returnToPlayer());
                break;
            }
            

            scriptLol.troopGetIndex = recieveData.getTroopIndex;
            scriptLol.troopID = troop.troopIndex.IndexOf(recieveData.getTroopIndex);
        }

        cameraScript = Camera.main.GetComponent<cameraMovement>();

        player.GetComponent<playerMovement>().controller.enabled = false;
        player.transform.position = loadList[0].playerPosition;
        player.GetComponent<playerMovement>().controller.enabled = true;
        playerMovement.playerHealth = loadList[0].playerHealth;

        saveTime.colorGet = loadList[0].colorGet_;
        saveTime.timeStep = loadList[0].timeStep_;
        saveTime.timestepClock = loadList[0].timestepClock_;

        saveTime.LoadTime(loadList[0].handRotation);

        for (int b = 0; b < 6; b++)
        {
            cameraScript.transposer.m_XAxis.Value = saveData.cameraX;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(Save());
        }

        if (PlayerPrefs.GetInt("loadingData") == 1)
        {
            Debug.Log("Pwetty pwease owo");
            Load();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Application.isEditor)
        {
            Load();
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

    void enemySave()
    {
        enemyWander[] enemiesAndObstacles = FindObjectsOfType<enemyWander>();

        foreach (enemyWander item in enemiesAndObstacles)
        {
            item.Save();
        }
    }

    void enemyLoad()
    {
        enemyWander[] enemiesAndObstacles = FindObjectsOfType<enemyWander>();

        foreach (enemyWander item in enemiesAndObstacles)
        {
            item.Load();
        }
    }
}

// Not made by me, Credit JP Silvashy

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
