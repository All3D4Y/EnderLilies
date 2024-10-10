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
    public event Action<SlotData> onDataChanged;
    public void SetData(string id, int newCount)
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
        onDataChanged?.Invoke(this);
    }
    public string GetData()
    {
        return dataID;
    }
}
public class InventoryData
{
    public List<SlotData> slotDatas;
    protected void InitializeSlots(int count)
    {
        slotDatas = new List<SlotData>(count);
        for (int i = 0; i < count; i++)
        {
            slotDatas.Add(new SlotData());
        }
    }
}
[Serializable]
public class SkillInventoryData : InventoryData
{
    public int inventoryCount = 18;
    public SkillInventoryData()
    {
        if (slotDatas == null || slotDatas.Count == 0)
        {
            InitializeSlots(inventoryCount);
            Debug.Log("초기화");
        }
        else
        {
            Debug.Log(slotDatas.Count);
        }
    }
}

[Serializable]
public class SkillEquipInventoryData : InventoryData
{
    public int inventoryCount = 3;
    public SkillEquipInventoryData()
    {
        if (slotDatas == null || slotDatas.Count == 0)
        {
            InitializeSlots(inventoryCount);
            Debug.Log("초기화");
        }
        else
        {
            Debug.Log(slotDatas.Count);
        }
    }
}