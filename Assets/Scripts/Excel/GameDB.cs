using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[ExcelAsset]
public class GameDB : ScriptableObject
{
	public List<SkillData> skillDatas;
    public SkillData GetSkillData(string id)
    {
        foreach (SkillData profile in skillDatas)
        {
            if (id == profile.dataID)
            {
                return profile;
            }
        }
        Debug.LogError("맞는 스킬 아이디 없음");
        return null;
    }
}
