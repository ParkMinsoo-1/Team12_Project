using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlotUI : MonoBehaviour, IDropHandler
{
    public Equip equipScript; // 플레이어의 Equip 스크립트
    public ItemDataSO itemData;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableUi draggedItem = eventData.pointerDrag.GetComponent<DraggableUi>();

        if (draggedItem != null)
        {
            if (itemData != null)
            {
                itemData = null;
                equipScript.UnEquipWeapon();
            }
            
            ItemDataSO droppedItemData = draggedItem.itemData;

            // 아이템 타입이 무기인지 확인
            if (droppedItemData.itemtype == Itemtype.weapon)
            {
                // 플레이어에게 장착 명령
                equipScript.EquipWeapon(droppedItemData);

                // 슬롯의 아이템 데이터 업데이트
                itemData = droppedItemData;

                Debug.Log(droppedItemData.itemName + "을(를) 장착했습니다!");
            }
            else
            {
                
                // 아이템 타입이 무기가 아니면 슬롯에 등록하지 않음
                Debug.Log("무기 슬롯에는 무기만 올릴 수 있어요!");

            }
        }
    }
}

