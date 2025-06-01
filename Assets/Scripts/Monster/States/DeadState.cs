using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeadState : IState
{
    NormalZombie zombie;
    public DeadState(NormalZombie zombie)
    {
        this.zombie = zombie;   
    }

    float deadTimer = 0;

    public void Enter()
    {
        InitDead();
    }
    public void Update()
    {
        deadTimer += Time.deltaTime;

        if (deadTimer >= 3f)
        {
            zombie.RemoveThisZombie();
        }
    }
    public void Exit()
    {

    }
    private void InitDead()
    {
        deadTimer = 0;
        zombie.anim.SetTrigger("Dead");
    }
}
