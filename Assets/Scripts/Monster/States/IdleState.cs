using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IdleState : IState
{
    private NormalZombie zombie;

    float waitTimer; //InitIdle로 항상 0초기화
    bool wait;

    public IdleState(NormalZombie zombie)
    {
        this.zombie = zombie;
    }

    public void Enter()
    {
        InitIdle(); //idle상태에 필요한 값들 초기화
    }

    public void Update()
    {
        float distance = PlayerManager.Instance.CheckDistanceOfPlayer(zombie.transform.position);

        if (!wait)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= 3f)
            {
                wait = true;
                DecidePatrolDirection(); //정찰방향결정
                zombie.MessageToFsm(ZombieStateType.Patrol);
                return;
            }
            else if (zombie.zombieData.ChaseRange >= distance)
            {
                wait = true;
                zombie.MessageToFsm(ZombieStateType.Chase);
                return;
            }
        }
    }
    public void Exit() 
    {
        zombie.anim.SetTrigger("Reset");
        //애니메이션 초기화
    }
    private void DecidePatrolDirection()
    {
        int y = Random.Range(0, 360);
        Quaternion angle = Quaternion.Euler(0, y, 0);

        zombie.patrolDirection = (angle * Vector3.forward).normalized;
        //랜덤으로 구해진 각도를 기준으로 앞을 보는 방향벡터
    }
    private void InitIdle()
    {
        wait = false;
        waitTimer = 0f;
        zombie.anim.SetFloat("MoveSpeed", 0); 
        //0 = idle   1 = 앞으로   -1 = 뒤로
        //좀비 행동(애니메이션) 초기화 idle상태로
        zombie.patrolDirection = Vector3.zero;
    }
}