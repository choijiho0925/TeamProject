using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_AnimContorller : MonoBehaviour
{
    Animator animator;
    PlayerController controller;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerController>();
    }

    private readonly int hashMove = Animator.StringToHash("IsMove");
    private readonly int hashJump = Animator.StringToHash("IsJumping");
    private readonly int hashFall = Animator.StringToHash("IsFalling");
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hashDie = Animator.StringToHash("IsDie");

    private void FixedUpdate()
    {
        OnAnimatorMove();
        OnAnimationJump(controller._rigidbody2D.velocity.y, controller.IsGrounded());
        OnAnimationAttack();
        OnAnimationDie();
    }

    private void OnAnimatorMove()
    {
        bool isMove = Mathf.Abs(controller.moveValue.x) != 0;
        animator.SetBool("IsMove", isMove);
    }

    private void OnAnimationJump(float yValue, bool isGrounded)
    {
        bool jump = yValue > 0f;
        bool fall = yValue < 0f;

        animator.SetBool("IsJumping", !isGrounded && jump);
        animator.SetBool("IsFalling", !isGrounded && fall);
    }

    private void OnAnimationAttack()
    {        
        animator.SetBool("IsAttack", controller.isAttack);
    }

    private void OnAnimationDie()
    {
        if(controller.isDead)
        animator.SetBool("IsDie", true);
    }
}
