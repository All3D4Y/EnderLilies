using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuickSkillSlotUI : MonoBehaviour 
{
    public int index;
    [SerializeField] Image skillImage;

    public void  SetUI(SlotData data)
    {
        skillImage.sprite = Resources.Load<Sprite>(GameManager.instance.gameDB.GetGameData(data.dataID).iconPath);
    }
}
