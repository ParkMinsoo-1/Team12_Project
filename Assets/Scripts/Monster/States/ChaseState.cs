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
        Debug.Log("추격상태 진입");
    }
    public void Update()
    {
        Debug.Log("추격상태 업데이트");
        Vector3 moveDirection = new Vector3(
            PlayerManager.Instance.Player.transform.position.x - myTransform.position.x, 
            0, 
            PlayerManager.Instance.Player.transform.position.z - myTransform.position.z).normalized;

        myRigid.MovePosition(myRigid.position +(moveDirection * 5f * Time.deltaTime));
    }
    public void Exit()
    {
        Debug.Log("추격상태 탈출");
    }
}
