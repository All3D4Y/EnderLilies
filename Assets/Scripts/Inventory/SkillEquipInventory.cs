using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEquipInventory : BaseInventory
{
    private SkillEquipInventoryData skillEquipInventoryData;
    QuickSkillSlotsUI quickSkillSlotsUI;

    protected override void Awake()
    {
        base.Awake();
        quickSkillSlotsUI = FindObjectOfType<QuickSkillSlotsUI>();
        skillEquipInventoryData = GameData.instance.skillEquipInventoryData;
        SetSlotCount(skillEquipInventoryData.inventoryCount);
        SetSlotData();
    }
    void SetSlotData()
    {
        for (int i = 0; i < skillEquipInventoryData.inventoryCount; i++)
        {
            skillEquipInventoryData.slotDatas[i].onDataChanged += slots[i].SetDataUI;
            slots[i].SetDataUI(skillEquipInventoryData.slotDatas[i]);
        }
    }
}
