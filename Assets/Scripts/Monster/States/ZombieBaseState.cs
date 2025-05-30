using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IState
{
    void Enter();
    void Update();
    void Exit();
}

public abstract class ZombieBaseState : MonoBehaviour
{
    //protected IdleState idle = new IdleState();
    //protected ChaseState move = new ChaseState();
    //protected AttackState attack = new AttackState();

    //public Animator anim;
    //public Rigidbody rigid;


}
