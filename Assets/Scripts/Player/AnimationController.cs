using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 playerDirection)
    {
        animator.SetBool("IsMove", playerDirection.magnitude > 0.9f);
        isMove = true;
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
        animator.SetTrigger("IsGathering");
    }

    public void GatherAndMove()
    {
        if (isMove = true)
        {
            animator.SetBool("OnMove", true);
        }
    }
}


