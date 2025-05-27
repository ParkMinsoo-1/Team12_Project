using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 playerDirection)
    {
        animator.SetBool("IsMove", playerDirection.magnitude > 0.9f);
    }
}
