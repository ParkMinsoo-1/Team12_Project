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
    //    //.performed - �Է��� ��Ȯ�� ����� ������ (���� ����)
    //    //context.started - �Է��� ���۵� �������� (���������)
    //    //context.canceled	- �Է��� ��ҵ� ���� (��ư�� ���� ��)
    //    //context.ReadValue<T>() - �Էµ� ���� �� �б� ����2 �÷� �� ��
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
