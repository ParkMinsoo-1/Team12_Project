using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IdleState : IState
{
    private NormalZombie zombie;

    float waitTimer; //InitIdle�� �׻� 0�ʱ�ȭ
    bool wait;

    public IdleState(NormalZombie zombie)
    {
        this.zombie = zombie;
    }

    public void Enter()
    {
        InitIdle(); //idle���¿� �ʿ��� ���� �ʱ�ȭ
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
                DecidePatrolDirection(); //�����������
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
        //�ִϸ��̼� �ʱ�ȭ
    }
    private void DecidePatrolDirection()
    {
        int y = Random.Range(0, 360);
        Quaternion angle = Quaternion.Euler(0, y, 0);

        zombie.patrolDirection = (angle * Vector3.forward).normalized;
        //�������� ������ ������ �������� ���� ���� ���⺤��
    }
    private void InitIdle()
    {
        wait = false;
        waitTimer = 0f;
        zombie.anim.SetFloat("MoveSpeed", 0); 
        //0 = idle   1 = ������   -1 = �ڷ�
        //���� �ൿ(�ִϸ��̼�) �ʱ�ȭ idle���·�
        zombie.patrolDirection = Vector3.zero;
    }
}