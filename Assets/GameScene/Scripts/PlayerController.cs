using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private bool isJumping = false;
    [SerializeField] private Transform groundCheck; // Raycast 발사 지점
    [SerializeField] private float groundCheckDistance = 0.1f; // Raycast 거리
    [SerializeField] private LayerMask groundLayer; // 감지할 레이어

    SpriteRenderer spriteRenderer;
    private Vector2 moveInput;

    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 5f;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // 항상 수평 이동 입력 반영
        _rigidbody2D.velocity = new Vector2(moveInput.x * moveSpeed, _rigidbody2D.velocity.y);

        // Raycast를 사용하여 땅 감지
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        isJumping = !hit; // Raycast가 충돌하지 않았으면 공중에 있다고 판단

        // (디버깅용) Raycast 시각화
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckDistance, hit ? Color.green : Color.red);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0) { spriteRenderer.flipX = false; }
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            isJumping = true;
        }
    }
}
