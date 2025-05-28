using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public Item item;
    public GameObject curInteractObject;
    public ItemDataSO itemData;
   
    
    // 상호작용 아이템 인식 방법 변경
    // public void Update()
    // {
    //     CheckInteract();
    // }
    // void CheckInteract()
    // {
    //     if (Time.time - lastCheckTime > checkRate)
    //     {
    //         lastCheckTime = Time.time;
    //         // Ray 시작 위치 (캐릭터 중심에서 약간 위로 올려도 됨)
    //         Vector3 rayOrigin = PlayerManager.Instance.Player.transform.position;
    //         Vector3 rayDirection = PlayerManager.Instance.Player.transform.forward;
    //
    //         // Ray 길이
    //         float rayDistance = 2f;
    //
    //         // 디버그용 Ray 시각화
    //         Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.green);
    //
    //         // Raycast
    //         if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, rayDistance))
    //         {
    //
    //             // 예: 특정 태그/레이어만 상호작용
    //             if (hit.collider.CompareTag("Interactable"))
    //             {
    //                 // 충돌한 오브젝트가 있으면
    //                 Debug.Log("상호작용 대상 발견: " + hit.collider.name);
    //             }
    //         }
    //     }
    // }
    
    private void OnTriggerEnter(Collider other)
    {
        item = other.gameObject.GetComponent<Item>();
        if (item != null)
        {
            curInteractObject = item.gameObject;
            if (curInteractObject != null && curInteractObject.layer == LayerMask.NameToLayer("ItemObject"))
            {
                itemData = item.ItemData;
                Debug.Log("상호작용 가능한 아이템이 있습니다." + curInteractObject.name);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        item = null;
        curInteractObject = null;
        itemData = null;
        Debug.Log("상호작용 가능한 아이템이 없습니다.");
    }
    public void OnInteractInput(InputAction.CallbackContext context) //아이템 상호작용 함수 받아오고 연결할 예정
    {
        if(context.phase == InputActionPhase.Started && curInteractObject != null)
        {
            if (curInteractObject != null)
            {
                InventoryManager.Instance.PickUp(itemData);
                item.RemoveItem();
                item = null;
                curInteractObject = null;
                itemData = null;
            }
        }
    }


}
