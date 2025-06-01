using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatrolState : IState
{
    private NormalZombie zombie;

    Vector3 firstPos;
    float patrolSpeed;
    float patrolAngle;
    int patrolDistance;

    public PatrolState(NormalZombie zombie)
    {
        this.zombie = zombie;
    }

    public void Enter()
    {
        InitPatrol();
    }
    public void Update()
    {
        float distanceOfPatrol = Vector3.Distance(firstPos, zombie.transform.position);
        float distanceOfPlayer = PlayerManager.Instance.CheckDistanceOfPlayer(zombie.transform.position);

        if (zombie.zombieData.ChaseRange >= distanceOfPlayer)
        {
            zombie.MessageToFsm(ZombieStateType.Chase);
            return;
        }

        if (distanceOfPatrol >= patrolDistance)
        {
            zombie.MessageToFsm(ZombieStateType.Idle);
            return;
        }

        zombie.rigid.MovePosition(zombie.rigid.position + (zombie.patrolDirection * patrolSpeed *Time.deltaTime));

    }
    public void Exit()
    {
        zombie.anim.SetFloat("MoveSpeed", 0);
        zombie.anim.SetTrigger("Reset");
    }
    private void InitPatrol()
    {
        zombie.anim.SetFloat("MoveSpeed", 1);
        
        firstPos = zombie.rigid.position;

        patrolSpeed = Random.Range(1f, 6f);
        patrolDistance = Random.Range(3, 10);


        patrolAngle = Mathf.Atan2(zombie.patrolDirection.x, zombie.patrolDirection.z) * Mathf.Rad2Deg;
        zombie.myBody.rotation = Quaternion.Euler(0, patrolAngle, 0);

    }

}
