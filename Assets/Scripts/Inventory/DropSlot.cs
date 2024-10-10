using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private SlotData slotData;
    DragSlot dragSlot;
    public InventoryType inventoryType;
    [SerializeField] Image backGroundImage;
    [SerializeField] Image dataImage;
    [SerializeField] Text countText;
    private void Awake()
    {
        dragSlot = GetComponentInChildren<DragSlot>();
    }
    public void SetData(SlotData slotData)
    {
        this.slotData = slotData;
        SetDataUI(slotData);
    }
    public void SetDataUI(SlotData slotData)
    {
        if (!string.IsNullOrEmpty(slotData.dataID))
        {
            dataImage.sprite = Resources.Load<Sprite>(GameManager.instance.gameDB.GetGameData(slotData.dataID).iconPath);
            if (dragSlot != null)
            {
                dragSlot.UpdateIconImage(Resources.Load<Sprite>(GameManager.instance.gameDB.GetGameData(slotData.dataID).iconPath));
            }
        }
        countText.text = slotData.count.ToString();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (inventoryType != InventoryType.EquipInventory)
        {
            return;
        }
        SlotData data = eventData.pointerDrag.GetComponent<DragSlot>().dropSlot.slotData;
        if (data != null)
        {
            SetData(data);
            EventManager.instance.ChangedEquipSkill(GameManager.instance.gameDB.GetGameData(slotData.dataID).iconPath);
        }
    }
}
