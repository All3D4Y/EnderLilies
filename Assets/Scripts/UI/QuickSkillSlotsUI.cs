using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuickSkillSlotsUI : MonoBehaviour 
{
    public GameObject quickSkillSlotPrefab;
    List<QuickSkillSlotUI> quickSkillSlotUI;
    private void Awake()
    {
        quickSkillSlotUI = new List<QuickSkillSlotUI>();
        for(int i=0; i<3; i++)
        {
            QuickSkillSlotUI newSlot = Instantiate(quickSkillSlotPrefab, transform).GetComponent<QuickSkillSlotUI>();
            newSlot.index = i;
            quickSkillSlotUI.Add(newSlot);
            EventManager.instance.onChangedEquipSkill += newSlot.SetUI;
        }
    }
}
