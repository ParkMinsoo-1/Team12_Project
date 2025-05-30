using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private NormalZombie zombie;
    public IdleState(NormalZombie zombie)
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
