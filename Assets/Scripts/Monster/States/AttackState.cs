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

    public void Enter()
    {

    }
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
