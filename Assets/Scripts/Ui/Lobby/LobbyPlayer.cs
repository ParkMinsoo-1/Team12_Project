using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyPlayer : MonoBehaviour
{

    [SerializeField] Vector2 testF;


    public void OnInterction(InputAction.CallbackContext context)
    {
        testF = context.ReadValue<Vector2>(); 
    }
    //public void OnJump(InputAction.CallbackContext context)
    //{
    //    bool isGround = CheckTheGround();

    //    if (context.performed && isGround && !anim.GetBool("isJump"))
    //    //.performed - 입력이 정확히 실행된 시점에 (누른 순간)
    //    //context.started - 입력이 시작된 순간부터 (누르기시작)
    //    //context.canceled	- 입력이 취소된 순간 (버튼을 땟을 때)
    //    //context.ReadValue<T>() - 입력된 실제 값 읽기 벡터2 플롯 불 등
    //    {
    //        anim.SetBool("isJump", true);
    //        PlayerJump(1);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
}
