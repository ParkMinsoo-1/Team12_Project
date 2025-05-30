using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUi : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    protected Image image;
    protected RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    //���콺�����Ͱ� �ݶ��̴�ó�� �ڽ��� �����ȿ� ������ ��
    //�� ������ ������Ʈ ��ü �����ε���
    {
        if(image != null)
            image.color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    //���콺�����Ͱ� �ݶ��̴�ó�� �ڽ��� �����ȿ��� ������ ��
    {
        if(image != null)
            image.color = Color.white;
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {

            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }

    }
}
