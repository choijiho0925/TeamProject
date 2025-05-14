using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public LayerMask firePlayerLayer; // 퉁사후르 레이어 설정
    public Animator animator;
    public Sprite damagedSprite;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    Collider2D col;
    public int hitCount = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = rb.GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            hitCount++;

            if (hitCount == 1)
            {
                Debug.Log("Hit Count: " + hitCount);
                sr.sprite = damagedSprite;
                animator.SetTrigger("IsAttack");
            }
            else if (hitCount == 2)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                Vector2 Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
                rb.AddForce(Direction * 5f, ForceMode2D.Impulse);
                rb.AddTorque(-5f, ForceMode2D.Impulse);
                //아직 퉁사후르 공격이 없어서 테스트 안해봤음
                animator.SetTrigger("IsAttack");
                Destroy(gameObject, 2f);
            }
        }
    }
}
