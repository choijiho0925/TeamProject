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
    }

    private void OnAnimatorMove()
    {
        bool isMove = Mathf.Abs(controller.moveValue.x) != 0;
        animator.SetBool("IsMove", isMove);
    }
}
