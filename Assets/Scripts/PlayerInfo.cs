using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerInfo Instance;

    public string name { get; set; }
    public int score { get; set; }

    public SaveData saveData { get;private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            this.score = 0;
            DontDestroyOnLoad(gameObject);
            LoadPlayerInfor();
        }

        
    }

    [System.Serializable]
    public class PlayerInfoData
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class SaveData
    {
        public PlayerInfoData[] playersInfo;

        public SaveData()
        {
            this.playersInfo = new PlayerInfoData[10];
        }
    }

    public void setName(string name)
    {
        if(name != "")
        {
            this.name = name;
            
        }
        else
        {
            this.name = "Unknown";
        }
        Debug.Log("Set Player Name to : " + this.name);
    }

    public void SavePlayerInfor()
    {
        PlayerInfoData data = new PlayerInfoData();
        data.name = this.name;
        data.score  = this.score;

        /*this.saveData.playersInfo.Add(data);*/

        string json = JsonUtility.ToJson(this.saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerInfor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data == null)
            {
                data = new SaveData();
            }
            this.saveData = data;
        }
        else
        {
            this.saveData = new SaveData();
        }
    }
}
