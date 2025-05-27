using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            
        }
    }
}
    void CheckInteract()
    {
        // Ray 시작 위치 (캐릭터 중심에서 약간 위로 올려도 됨)
        Vector3 rayOrigin = transform.position + Vector3.up * 0.5f;
        Vector3 rayDirection = transform.forward;

        // Ray 길이
        float rayDistance = 2f;

        // 디버그용 Ray 시각화
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.green);

        // Raycast
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, rayDistance))
        {
            // 충돌한 오브젝트가 있으면
            Debug.Log("상호작용 대상 발견: " + hit.collider.name);

            // 예: 특정 태그/레이어만 상호작용
            if (hit.collider.CompareTag("Interactable"))
            {
                // 상호작용 함수 실행
                Interact(hit.collider.gameObject);
            }
        }
    }
}
