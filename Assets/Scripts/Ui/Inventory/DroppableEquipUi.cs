using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableEquipUi : DroppableUi
{
    public Image toolImage;
    public Equip equipScript; // 플레이어의 Equip 스크립트
    public ItemDataSO itemData;

    public void ShowSilhouette()
    {
        toolImage.enabled = true;
    }
    
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DraggableUi draggedItem = eventData.pointerDrag.GetComponent<DraggableUi>();

            if (draggedItem != null)
            {
                ItemDataSO droppedItemData = draggedItem.itemData;

                // 슬롯에 이미 아이템이 있으면 해제
                if (itemData != null)
                {
                    equipScript.UnEquipWeapon();
                    itemData = null;
                }

                // 아이템 타입 확인
                if (droppedItemData.itemtype == Itemtype.weapon)
                {
                    toolImage.enabled = false;  

                    // 슬롯에 아이템 올리기
                    eventData.pointerDrag.transform.SetParent(transform);
                    eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

                    // 장착 처리
                    equipScript.EquipWeapon(droppedItemData);
                    itemData = droppedItemData;

                    Debug.Log(droppedItemData.itemName + "을(를) 장착했습니다!");
                }
                else
                {
                    // 무기가 아니면 다시 원래 자리로!
                    Debug.Log("무기 슬롯에는 무기만 올릴 수 있어요!");
                    draggedItem.ResetToOrigin();
                }
            }
        }
    }
}

