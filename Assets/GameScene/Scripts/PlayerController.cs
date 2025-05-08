using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private bool isJumping = false;
    [SerializeField] private Transform groundCheck; // Raycast �߻� ����
    [SerializeField] private float groundCheckDistance = 0.1f; // Raycast �Ÿ�
    [SerializeField] private LayerMask groundLayer; // ������ ���̾�

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
        // �׻� ���� �̵� �Է� �ݿ�
        _rigidbody2D.velocity = new Vector2(moveInput.x * moveSpeed, _rigidbody2D.velocity.y);

        // Raycast�� ����Ͽ� �� ����
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        isJumping = !hit; // Raycast�� �浹���� �ʾ����� ���߿� �ִٰ� �Ǵ�

        // (������) Raycast �ð�ȭ
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
