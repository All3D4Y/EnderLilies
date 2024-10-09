using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SlotData
{
    public string dataID;
    public int count;
    public int maxCount = 99;
    public void AddData(string id, int newCount)
    {
        if (id == null || newCount <= 0)
        {
            return;
        }

        if (dataID == null || dataID != id)
        {
            dataID = id;
            count = newCount;
        }
        else
        {
            count += newCount;
            if (count > maxCount)
            {
                return;
            }
        }
    }
    public void RemoveData()
    {
        dataID = null;
        count = 0;
    }
    public string GetData()
    {
        return dataID;
    }
}
[Serializable]
public class SkillInventoryData
{
    public List<SlotData> skillSlotDatas;
    private void InitializeSlots(int count)
    {
        skillSlotDatas = new List<SlotData>(count);
        for (int i = 0; i < count; i++)
        {
            skillSlotDatas.Add(new SlotData());
        }
    }
    public SkillInventoryData()
    {
        if (skillSlotDatas == null || skillSlotDatas.Count == 0)
        {
            InitializeSlots(18);
            Debug.Log("ÃÊ±âÈ­");
        }
        else
        {
            Debug.Log(skillSlotDatas.Count);
        }
    }
}