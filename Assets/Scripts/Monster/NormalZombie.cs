using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    private IdleState idle = new IdleState();
    private MoveState move = new MoveState();
    //상태들을 담아줌 -> 상태를 변경할 때 마다 new로 할당하는건 비효율적

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
