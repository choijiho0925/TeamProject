using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriterenderer;

    private Vector2 moveValue;
    public float moveSpeed = 5f;
    public bool isJumping = false;
    public float jumpForce = 5f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(moveValue.x * moveSpeed, _rigidbody2D.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isJumping = false;
        }
        
    }
}
