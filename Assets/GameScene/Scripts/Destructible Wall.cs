using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public LayerMask firePlayerLayer; // �����ĸ� ���̾� ����
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
                    //�ݶ��̴� ���ְ� ���� ���ӿ���ó�� ���� ƨ���� ���������ϱ�
                    animator.SetTrigger("Shake");
                    Destroy(this, 1f);
                }
            }    
        }
    }
}
