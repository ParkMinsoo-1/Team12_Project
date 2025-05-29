using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private float attackDelay = 0.5f;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 playerDirection)
    {
        animator.SetBool("IsMove", playerDirection.magnitude > 0.9f);
    }

    public void Attack()
    {
        animator.SetTrigger("IsAttack");
        EndAttack();
        
    }

    public void EndAttack()
    {
        PlayerManager.Instance.Player._playerController.isAttack = false;
    }

    public void Damaged()
    {
        
    }

    public void Gather()
    {
        animator.SetTrigger("IsGather");
    }
}
