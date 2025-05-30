using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlotUI : MonoBehaviour, IDropHandler
{
    public Equip equipScript;  // 플레이어의 Equip 스크립트

    public void OnDrop(PointerEventData eventData)
    {
        DraggableUi draggedItem = eventData.pointerDrag.GetComponent<DraggableUi>();

        if (draggedItem != null)
        {
            ItemDataSO itemData = draggedItem.itemData;

            // 아이템 타입이 무기인지 확인
            if (itemData.itemtype == Itemtype.weapon)
            {
                // 플레이어에게 장착 명령
                equipScript.EquipWeapon(itemData);

                Debug.Log(itemData.itemName + "을(를) 장착했습니다!");
            }
            else
            {
                Debug.Log("무기 슬롯에는 무기만 올릴 수 있어요!");
            }
        }
    }
}
