using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    private static GameData _instance;
    public static GameData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    public PlayerStatus playerStatus;
    public SkillInventoryData skillInventoryData;
    public SkillEquipInventoryData skillEquipInventoryData1;
    public SkillEquipInventoryData skillEquipInventoryData2;
    public GameData()
    {
        playerStatus = new PlayerStatus();
        skillInventoryData = new SkillInventoryData();
        skillEquipInventoryData1 = new SkillEquipInventoryData();
        skillEquipInventoryData2 = new SkillEquipInventoryData();
        // Save();
    }
    [ContextMenu("Save To Json Data")]
    public void Save()
    {
        string jsonData = JsonUtility.ToJson(this, true);
        string path = Path.Combine(Application.dataPath, "UserData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("Load From Json Data")]
    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "UserData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(jsonData, instance);
        }
    }
}