using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public LayerMask firePlayerLayer; // 퉁사후르 레이어 설정
    public Animator animator;
    public Sprite damagedSprite;
    private SpriteRenderer sr;

    int hitCount = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Animator playerAnim = collision.GetComponent<Animator>();
            if (playerAnim != null && playerAnim.GetBool("IsAttacking"))
            {
                hitCount++;

                if(hitCount == 1)
                {
                    sr.sprite = damagedSprite;
                    animator.SetTrigger("Shack");
                } 
                else if(hitCount == 2)
                {
                    //콜라이더 없애고 스택 게임오버처럼 위로 튕긴후 떨어지게하기
                    animator.SetTrigger("Shake");
                    Destroy(this, 1f);
                }
            }    
        }
    }
}
