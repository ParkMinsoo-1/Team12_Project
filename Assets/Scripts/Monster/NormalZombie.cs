using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    protected IdleState idle;
    protected ChaseState chase;
    protected AttackState attack;
    //protected AttackState attack = new AttackState(this);
    //여기서 바로 초기화로 this를 넘겨주는건 못 쓴다.
    //왜? -> 그 시점에서는 this가 완전히 생성되지 않았기 때문

    public Animator anim;
    public Rigidbody rigid;

    private IState currentState;
    private IState nextState;
    bool isState = false;

    public ZombieData zombieData;

    private void Awake()
    {
        idle = new IdleState(this);
        chase = new ChaseState(this);
        attack = new AttackState(this);
    }

    private void Update()
    {
        currentState?.Update();
    }
    private void LateUpdate()
    {
        if (!isState)
        {
            MakeDecision();
        }
    }

    private void ChangeState(IState choice)
    {
        nextState = choice;

        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }

    private void MakeDecision()
    {
        float distance = PlayerManager.Instance.CheckDistanceOfPlayer(transform.position);
        if (zombieData.ChaseRange >= distance)
        {
            isState = true;
            ChangeState(chase);
            return;
        }

        ChangeState(idle);
    }
    

}
