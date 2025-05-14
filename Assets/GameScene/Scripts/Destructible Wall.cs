using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public LayerMask firePlayerLayer; // 퉁사후르 레이어 설정
    public Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    CircleCollider2D col;
    int hitCount = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = rb.GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(CircleCollider2D collision)
    {
        
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Animator playerAnim = collision.GetComponent<Animator>();
            if (playerAnim != null && playerAnim.GetBool("IsAttacking"))
            {
                hitCount++;

                if(hitCount == 1)
                {
                    animator.SetTrigger("IsAttack");
                } 
                else if(hitCount == 2)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    Vector2 Direction = new Vector2(Random.Range(-1f,1f),Random.Range(0.5f,1f)).normalized;
                    rb.AddForce(Direction*5f,ForceMode2D.Impulse);
                    rb.AddTorque(-5f, ForceMode2D.Impulse);
                    //아직 퉁사후르 공격이 없어서 테스트 안해봤음
                    animator.SetTrigger("IsAttack");
                    Destroy(gameObject, 1f);
                }
            }    
        }
    }
}
