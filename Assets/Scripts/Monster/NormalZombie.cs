using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    private IdleState idle = new IdleState();
    private MoveState move = new MoveState();
    //���µ��� ����� -> ���¸� ������ �� ���� new�� �Ҵ��ϴ°� ��ȿ����

    private IState currentState;

    private void Update()
    {
        currentState?.Update();
    }

    private void ChangeState()
    {
        currentState?.Exit();
        currentState = idle;
    }

    private void MakeDecision()
    {

    }
    

}
