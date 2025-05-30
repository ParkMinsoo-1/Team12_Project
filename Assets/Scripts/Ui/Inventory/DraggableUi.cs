using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private UnityEngine.UI.Image itemIcon;
    public ItemDataSO itemData;

    private void Awake()
    {
        inventoryUi = FindObjectOfType<InventoryUi>().transform;
        rect = GetComponent<RectTransform>();
        itemGroup = GetComponent<CanvasGroup>();  
        itemIcon = GetComponent<UnityEngine.UI.Image>();
    }
    private void Start()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
        }
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
    public void ResetToOrigin()
    {
        // 원래 부모로 되돌리기
        transform.SetParent(previousParent);

        // 원래 부모 위치로 되돌리기
        rect.position = previousParent.GetComponent<RectTransform>().position;

        // 드래그 완료 후 다시 Raycast 처리 가능하게
        itemGroup.blocksRaycasts = true;
    }
}
