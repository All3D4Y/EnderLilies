using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : BaseInventory
{
    private SkillInventoryData skillInventoryData;

    protected override void Awake()
    {
        base.Awake();
        skillInventoryData = GameData.instance.skillInventoryData;
        SetSlotCount(skillInventoryData.inventoryCount);
        SetSlotData();
    }
    void SetSlotData()
    {
        for (int i = 0; i < skillInventoryData.inventoryCount; i++)
        {
            skillInventoryData.slotDatas[i].onDataChanged += slots[i].SetDataUI;
            slots[i].SetDataUI(skillInventoryData.slotDatas[i]);
        }
    }
}
