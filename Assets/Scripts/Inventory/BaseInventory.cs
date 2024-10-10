using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    Inventory,
    EquipInventory
}
public class BaseInventory : MonoBehaviour
{
    public GameObject slotPrefab; 
    public int slotCount;
    protected List<DropSlot> slots;

    protected virtual void Awake()
    {
        slots = new List<DropSlot>();
    }
    public void AddSlot()
    {
        DropSlot newSlot = Instantiate(slotPrefab, transform).GetComponentInChildren<DropSlot>(); 
        slots.Add(newSlot);
    }
    public void SetSlotCount(int newCount)
    {
        int currentCount = slots.Count;

        if (newCount > currentCount)
        {
            for (int i = currentCount; i < newCount; i++)
            {
                AddSlot();
            }
        }
        else if (newCount < currentCount)
        {
            for (int i = currentCount - 1; i >= newCount; i--)
            {
                Destroy(slots[i]);
                slots.RemoveAt(i);
            }
        }
    }
}
