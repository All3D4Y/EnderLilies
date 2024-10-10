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

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>().transform;
        originalPosition = rectTransform.anchoredPosition; 
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;
        transform.SetParent(canvas);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;// �巡�� ���� �� Raycast ��Ȱ��ȭ
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
    public void UpdateIconImage(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }
}
