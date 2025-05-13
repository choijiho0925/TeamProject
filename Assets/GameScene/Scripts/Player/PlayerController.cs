using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; // 점프를 초기화시킬 레이어를 가진 객체 설정
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask obstacleLayer;

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    private Vector2 moveValue;  // 이동 값(거리)
    public float moveSpeed = 5f;    // 이동 속도
    public float jumpForce = 5f;    // 점프력

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void FixedUpdate()
    {
        if (moveValue.x == 0)
        {
            // 멈췄을때 그자리에 바로서게 예외처리
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
        // 레이캐스트 범위에 groundLayer가 없을때만 이동가능하게 예외처리
        if ((moveValue.x < 0 && !IsTouchingWall(Vector2.left)) ||
            (moveValue.x > 0 && !IsTouchingWall(Vector2.right)))
        {
            _rigidbody2D.velocity = new Vector2(moveValue.x * moveSpeed, _rigidbody2D.velocity.y);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();   // 좌우 이동 구현
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())    // 중복점프 방지
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);    // 점프 구현
        }
    }

    private bool IsTouchingWall(Vector2 direction)
    {
        Bounds bounds = _boxCollider2D.bounds;

        Vector2 boxSize = new Vector2(bounds.size.x * 0.9f, bounds.size.y * 0.8f); // 체크박스 크기 약간 작게
        Vector2 origin = bounds.center;

        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, direction, 0.1f, wallLayer);

        return hit.collider != null;
    }

    private bool IsGrounded()
    {
        // 공중에서 무한점프 불가능하게 설정
        Bounds bounds = _boxCollider2D.bounds;
        Vector2 boxSize = new Vector2(bounds.size.x * 0.9f, 0.1f);
        Vector2 origin = new Vector2(bounds.center.x, bounds.min.y - 0.05f);

        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, Vector2.down, 0.01f, groundLayer);
        RaycastHit2D hit2 = Physics2D.BoxCast(origin, boxSize, 0f, Vector2.down, 0.01f, obstacleLayer);
        return hit.collider || hit2.collider != null;
    }
    public void Dead()
    {
        //플레이어 사망 애니메이션 출력
        Destroy(gameObject);
        GameManager.Instance.isPlayingGame = false;
        GameManager.Instance.isSuccess = false;
        GameManager.Instance.GameOver();
    }
}

