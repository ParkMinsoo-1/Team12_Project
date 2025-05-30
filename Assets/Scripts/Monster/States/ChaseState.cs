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
        Debug.Log("�߰ݻ��� ����");
    }
    public void Update()
    {
        Debug.Log("�߰ݻ��� ������Ʈ");
        Vector3 moveDirection = new Vector3(
            PlayerManager.Instance.Player.transform.position.x - myTransform.position.x, 
            0, 
            PlayerManager.Instance.Player.transform.position.z - myTransform.position.z).normalized;

        myRigid.MovePosition(myRigid.position +(moveDirection * 5f * Time.deltaTime));
    }
    public void Exit()
    {
        Debug.Log("�߰ݻ��� Ż��");
    }
}
