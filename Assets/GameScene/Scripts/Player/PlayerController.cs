using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; // 점프를 초기화시킬 레이어를 가진 객체 설정
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask obstacleLayer;

    private SpriteRenderer _renderer;
    public Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private BoxCollider2D weaponCollider2D;

    public Vector2 moveValue;  // 이동 값(거리)
    public float moveSpeed = 5f;    // 이동 속도
    public float jumpForce = 5f;    // 점프력

    public bool isAttack = false;   // 공격 애니메이션 여부를 위한 불값
    public bool isDead = false;    // 사망 확인

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        weaponCollider2D = transform.Find("WeaponPivot")?.GetComponent<BoxCollider2D>();
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
            // 캐릭터 이미지 움직이는 방향을 향하게 플립
            if (moveValue.x < 0)
            {
                _renderer.flipX = false;
            }
            else
            {
                _renderer.flipX = true;
            }
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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            isAttack = true;
            OnHit();
        }
    }

    private bool IsTouchingWall(Vector2 direction)
    {
        Bounds bounds = _boxCollider2D.bounds;

        Vector2 boxSize = new Vector2(bounds.size.x, bounds.size.y);    // 박스 크기 설정
        Vector2 origin = bounds.center;   // 박스 중심 설정     

        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, direction, 0.1f, wallLayer);  // 충돌 레이어 설정 및 이동 방향에 따라 레이캐스트
        RaycastHit2D hit2 = Physics2D.BoxCast(origin, boxSize, 0f, direction, 0.1f, obstacleLayer);

        return hit.collider || hit2.collider != null;   // 하나라도 충돌하면 true 반환
    }

    public bool IsGrounded()
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
        isDead = true;
        GetComponent<PlayerInput>().enabled = false;    // 캐릭터 사망시 인풋시스템 비활성화
        StartCoroutine(DestroyAfterDelay(1f));  // 사망 애니메이션 출력후 오브젝트 제거
        GameManager.Instance.isPlayingGame = false;
        GameManager.Instance.isSuccess = false;
    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        // 게임 오버 로직 실행
        GameManager.Instance.GameOver();
    }
    private IEnumerator AttackDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAttack = false;
        weaponCollider2D.enabled = false;
    }

    private void OnHit()
    {
        if(isAttack)
        {            
            weaponCollider2D.enabled = true;
            StartCoroutine(AttackDelay(0.5f));  // 공격 애니메이션
        }
    }
}

