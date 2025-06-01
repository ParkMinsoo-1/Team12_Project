using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private NormalZombie zombie;
    public AttackState(NormalZombie zombie)
    {
        this.zombie = zombie;
    }
    float attackTimer;
    float attackDuration = 1.75f;

    public void Enter()
    {
        InitAttack();
    }
    public void Update()
    {
        zombie.rigid.velocity = Vector3.zero;

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            zombie.MessageToFsm(ZombieStateType.Chase);
        }
    }
    public void Exit()
    {
        zombie.anim.SetTrigger("Reset");
    }
    private void InitAttack()
    {
        attackTimer = 0f;
        zombie.anim.SetTrigger("Attack");
    }
}
