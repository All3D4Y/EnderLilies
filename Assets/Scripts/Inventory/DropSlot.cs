using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] Image image;
    [SerializeField] Text countText;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null)
        {
            DragSlot dragSlot = draggedObject.GetComponent<DragSlot>();
            if (dragSlot != null)
            {
                draggedObject.transform.SetParent(transform);
                draggedObject.transform.localPosition = Vector3.zero; 
            }
        }
    }
}
