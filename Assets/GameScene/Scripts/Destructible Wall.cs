using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public LayerMask firePlayerLayer; // �����ĸ� ���̾� ����
    public Animator animator;
    private Rigidbody2D rb;
    int hitCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
            {
                      hitCount++;
                      Debug.Log(hitCount);
                    if (hitCount == 1)
                    {
                        animator.SetTrigger("IsAttack");

                    }
                    else if (hitCount > 2)
                    {
                        rb.bodyType = RigidbodyType2D.Dynamic;
                        Vector2 Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
                        rb.AddForce(Direction * 5f, ForceMode2D.Impulse);
                        rb.AddTorque(-5f, ForceMode2D.Impulse);
                        //���� �����ĸ� ������ ��� �׽�Ʈ ���غ���
                        animator.SetTrigger("IsAttack");
                        Destroy(gameObject, 1f);
                    }  
            }
        }
    }
