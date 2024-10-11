using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventManager
{
    private static EventManager _instance;
    public static EventManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventManager();
            }
            return _instance;
        }
    }


    public event Action<SlotData> onChangedEquipSkill;

    public void ChangedEquipSkill(SlotData data)
    {
        onChangedEquipSkill?.Invoke(data);
    }
}
