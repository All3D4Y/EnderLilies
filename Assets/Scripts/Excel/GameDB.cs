using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[ExcelAsset]
public class GameDB : ScriptableObject
{
	public List<GameDataDB> gameDatas;
    public GameDataDB GetGameData(string id)
    {
        foreach (GameDataDB profile in gameDatas)
        {
            if (id == profile.dataID)
            {
                return profile;
            }
        }
        Debug.LogError("�´� ��ų ���̵� ����");
        return null;
    }
}
