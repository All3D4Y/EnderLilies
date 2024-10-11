using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEquipInventory : BaseInventory
{
    [SerializeField] int skillEquipInventoryIndex;
    [SerializeField] QuickSkillSlotsUI quickSkillSlotsUI;
    private SkillEquipInventoryData skillEquipInventoryData;

    protected override void Awake()
    {
        base.Awake();
        QuickSkillSlotsUI[] slotsUI = FindObjectsOfType<QuickSkillSlotsUI>();
        if(slotsUI != null )
        {
            for( int i = 0; i < slotsUI.Length; i++ )
            {
                if(slotsUI[i].quickSkillSlotsIndex == skillEquipInventoryIndex)
                {
                    quickSkillSlotsUI = slotsUI[i];
                    break;
                }
            }
        }
        if (skillEquipInventoryIndex == 1)
        {
            skillEquipInventoryData = GameData.instance.skillEquipInventoryData1;
        }
        else if (skillEquipInventoryIndex == 2)
        {
            skillEquipInventoryData = GameData.instance.skillEquipInventoryData2;
        }
        SetSlotCount(skillEquipInventoryData.inventoryCount);
        SetSlotData();
    }
    void SetSlotData()
    {
        for (int i = 0; i < skillEquipInventoryData.inventoryCount; i++)
        {
            slots[i].slotData = skillEquipInventoryData.slotDatas[i];
            skillEquipInventoryData.slotDatas[i].onDataChanged += slots[i].SetDataUI;
            skillEquipInventoryData.slotDatas[i].onDataChanged += quickSkillSlotsUI.quickSkillSlotUI[i].SetUI;
            slots[i].SetDataUI(skillEquipInventoryData.slotDatas[i]);
        }
    }
}
