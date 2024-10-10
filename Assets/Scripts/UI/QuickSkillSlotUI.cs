using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuickSkillSlotUI : MonoBehaviour 
{
    public int index;
    [SerializeField] Image skillImage;

    public void  SetUI(string path)
    {
        skillImage.sprite = Resources.Load<Sprite>(path);
    }
}
