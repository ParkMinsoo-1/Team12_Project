using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    private NormalZombie zombie;
    Transform myTransform;
    Rigidbody myRigid;
    


    public ChaseState(NormalZombie zombie)
    {
        this.zombie = zombie;
        myTransform = zombie.transform;
        myRigid = zombie.rigid;
    }

    public void Enter()
    {
        InitChase();
    }
    public void Update()
    {
        float distanceOfPlayer = PlayerManager.Instance.CheckDistanceOfPlayer(zombie.transform.position);

        if (zombie.zombieData.AttackRange >= distanceOfPlayer)
        {
            zombie.MessageToFsm(ZombieStateType.Attack);
            return;
        }
        if (zombie.zombieData.ChaseRange <= distanceOfPlayer)
        {
            zombie.MessageToFsm(ZombieStateType.Idle);
            return;
        }

        Vector3 playerPos = PlayerManager.Instance.playerPos; 
        Vector3 myPos = zombie.transform.position;  

        Vector3 moveDirection = new Vector3 (playerPos.x - myPos.x, 0, playerPos.z - myPos.z).normalized;
        myRigid.MovePosition(myRigid.position + (moveDirection * zombie.zombieData.MoveSpeed * Time.deltaTime));

        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        zombie.myBody.rotation = Quaternion.Euler(0, targetAngle, 0);
    }
    public void Exit()
    {
        zombie.anim.SetFloat("MoveSpeed", 0);
        zombie.anim.SetTrigger("Reset");
    }
    private void InitChase()
    {
        zombie.anim.SetFloat("MoveSpeed", 1);
    }
}
