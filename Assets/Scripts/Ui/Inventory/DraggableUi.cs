using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DraggableUi : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform inventoryUi;

    private Transform previousParent;

    private RectTransform rect;

    private CanvasGroup itemGroup;
    //ui������ �������� �ڽ��� ���� ���� �ֱ⿡
    //�ڽı��� 
    protected ItemData itemData;

    private void Awake()
    {
        inventoryUi = FindObjectOfType<InventoryUi>().transform;
        rect = GetComponent<RectTransform>();
        itemGroup = GetComponent<CanvasGroup>();  
    
    }

    public void OnBeginDrag(PointerEventData evenData)
    {
        DroppableEquipUi equipSlot = transform.parent.GetComponent<DroppableEquipUi>();
        if (equipSlot != null)
        {
            equipSlot.ShowSilhouette();
            //inven
        }
        previousParent = transform.parent;
        //�巡�� ������ �ҼӵǾ��ִ� �θ��� Ʈ������ ���� ����
        transform.SetParent(inventoryUi);
        //�θ� ������Ʈ�� �κ��丮ĵ������ ����
        transform.SetAsLastSibling();
        //���� �տ� ���̵��� ������ ������ �ڽ����� ����

        itemGroup.blocksRaycasts = false;
        //���콺�� ������ �浹�� �� �ֵ���
        //�����۱׷��� �浹�� ���ش�.
    }
    public void OnDrag(PointerEventData evenData)
    {
        rect.position = evenData.position; 
        //�巡�� ���� �������� ��ġ�� ��ũ������ ���콺 ��ġ�� ����
    }
    public void OnEndDrag(PointerEventData evenData)
    {
        if (transform.parent == inventoryUi)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        itemGroup.blocksRaycasts = true;
    }

}
