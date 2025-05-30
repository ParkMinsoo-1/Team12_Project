using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Interaction : MonoBehaviour
{
    public Item item;
    public GameObject curInteractObject;
    public ItemDataSO itemData;
    public Crafting crafting;

   
    
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
        // if (other != null)
        // {
        //     switch (other.gameObject.tag)
        //     {
        //         case "Item":
        //             item = other.gameObject.GetComponent<Item>();
        //             curInteractObject = item.gameObject;
        //             itemData = item.ItemData;
        //             Debug.Log("상호작용 가능한 아이템이 있습니다." + curInteractObject.name);
        //             break;
        //         case "Craft":
        //             curInteractObject = other.gameObject.
        //     }
        // }
        if (other.TryGetComponent(out IInterctable target))
        {
            //ChangeButtonFunc
            InfoUi infoUi = UiManager.Instance.mainUi.infoLayout.GetComponent<InfoUi>();
            infoUi.ChangeButtonFunc(target.MyCase());
            UiManager.Instance.mainUi.UpdateInfoUi(target.MyInfo(), true);
        }

        if (other != null)
        {
            if (other.tag == "Item")
            {
                item = other.gameObject.GetComponent<Item>();
                curInteractObject = item.gameObject;
                if (curInteractObject != null && curInteractObject.layer == LayerMask.NameToLayer("ItemObject"))
                {
                    itemData = item.ItemData;
                    Debug.Log("상호작용 가능한 아이템이 있습니다." + curInteractObject.name);
                }
            }
            if (other.tag == "Craft")
            {
                curInteractObject = other.gameObject;
                Debug.Log("아이템 제작이 가능합니다.");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (UiManager.Instance.cardData != null)
        {
            UiManager.Instance.cardData = null;
        }
        UiManager.Instance.mainUi.UpdateInfoUi(null, false);

        item = null;
        curInteractObject = null;
        itemData = null;
    }
    public void OnInteractInput(InputAction.CallbackContext context) //아이템 줍기 E키
    {
        if(context.phase == InputActionPhase.Started && curInteractObject != null)
        {
            if (itemData != null)
            {
                PlayerManager.Instance.Player._playerController._animationController.Gather();
                InventoryManager.Instance.PickUp(itemData);
                item.RemoveItem();
                item = null;
                curInteractObject = null;
                itemData = null;
                
            }
        }
    }

    public void OnCraftInput(InputAction.CallbackContext context) //크래프팅 C키
    {
        if (context.phase == InputActionPhase.Started && curInteractObject != null)
        {
            if (!curInteractObject.CompareTag("Craft"))
            {
                Debug.Log("제작이 불가능합니다.");
            }
            else
            {
                CraftStation station = curInteractObject.GetComponent<CraftStation>();
                if (station != null && station.recipes != null)
                {
                    // Crafting 컴포넌트에서 제작 시도
                    crafting = GetComponent<Crafting>();
                    bool craft = crafting.Craft(station.recipes);
                    if (craft)
                    {
                        Debug.Log("제작이 완료되었습니다.");
                    }
                    else
                    {
                        Debug.Log("제작이 실패하였습니다.");
                    }
                }
                else
                {
                    Debug.Log("제작이 불가능합니다"); 
                }
            }
        }
    }
    


}
