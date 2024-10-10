using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGit : MonoBehaviour
{
    public DropSlot slot;
    public void Test()
    {
        SlotData slotData = new SlotData();
        slotData.dataID = "skill1";
        slotData.count = 10;
        slot.SetData(slotData);
    }
}
