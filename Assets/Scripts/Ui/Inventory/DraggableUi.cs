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
    //ui아이템 프리팹이 자식을 가질 수도 있기에
    //자식까지 
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
        //드래그 직전에 소속되어있던 부모의 트렌스폼 정보 저장
        transform.SetParent(inventoryUi);
        //부모 오브젝트를 인벤토리캔버스로 설정
        transform.SetAsLastSibling();
        //가장 앞에 보이도록 순서를 마지막 자식으로 설정

        itemGroup.blocksRaycasts = false;
        //마우스와 슬롯이 충돌할 수 있도록
        //아이템그룹의 충돌은 꺼준다.
    }
    public void OnDrag(PointerEventData evenData)
    {
        rect.position = evenData.position; 
        //드래그 중인 오브젝의 위치를 스크린상의 마우스 위치로 설정
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
