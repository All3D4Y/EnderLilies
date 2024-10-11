using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public DropSlot dropSlot;
    private Transform canvas;
    private Transform previousParent;
    [SerializeField] RectTransform slotsRectTransform;
    [SerializeField] Image iconImage;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    Button infoButton;
    public event Action<string> onUpdateExplain;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>().transform;
        originalPosition = rectTransform.anchoredPosition;
        infoButton = GetComponent<Button>();
        infoButton.onClick.AddListener(() => ExplainInfo(dropSlot.slotData.dataID));
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;
        transform.SetParent(canvas);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;// 드래그 중일 때 Raycast 비활성화
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rectTransform.position = previousParent.GetComponent<RectTransform>().position;
            //if (!RectTransformUtility.RectangleContainsScreenPoint(slotsRectTransform, eventData.position, null))
            //{

            //}
        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
    private float UpdateUIPos()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas.scaleFactor;
    }
    private void ExplainInfo(string id)
    {
        onUpdateExplain?.Invoke(id);
    }
    public void UpdateIconImage(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }
}
