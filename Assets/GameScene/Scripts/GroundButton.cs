using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    // Animator �Ķ���� �̸��� �̸� �ؽ÷� ��ȯ�� ĳ�� (���� ����ȭ)
    private static readonly int IsSwitch = Animator.StringToHash("IsSwitch");

    protected Animator animator;



    protected virtual void Awake()
    {
        // �ִϸ����� ������Ʈ�� �ڽĿ��� ������
        animator = GetComponentInChildren<Animator>();
    }


    public void GroundButtonSwitch()
    {
        // ���� ���� ���� ����
        animator.SetBool(IsSwitch, true);
    }

    public void GroundButtonNoSwitch()
    {
        // ���� ���� ���� ����
        animator.SetBool(IsSwitch, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //�׽�Ʈ��
        GroundButtonSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
