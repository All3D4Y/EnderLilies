using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGit : MonoBehaviour
{
    public DropSlot slot;
    public string dataid;
    public void Test()
    {
        SlotData slotData = new SlotData();
        slotData.dataID = dataid;
        slotData.count = 10;
        slot.SetData(slotData);
    }
}
