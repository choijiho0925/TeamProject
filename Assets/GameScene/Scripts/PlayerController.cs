using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; // 점프를 초기화시킬 레이어를 가진 객체 설정

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriterenderer;

    private Vector2 moveValue;  // 이동 값(거리)
    public float moveSpeed = 5f;    // 이동 속도
    public bool isJumping = false;  // 점프 여부
    public float jumpForce = 5f;    // 점프력

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(moveValue.x * moveSpeed, _rigidbody2D.velocity.y);  //수평 이동 처리
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();   // 좌우 이동 구현
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)    // 중복점프 방지
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);    // 점프 구현
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0) // 충돌체 레이어에 따라 점프 여부 초기화
        {
            isJumping = false;
        }
    }
}

