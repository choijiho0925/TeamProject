using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Animator �Ķ���� �̸��� �̸� �ؽ÷� ��ȯ�� ĳ�� (���� ����ȭ)
    private static readonly int IsSwitch = Animator.StringToHash("IsSwitch");

    protected Animator animator;


    protected virtual void Awake()
    {
        // �ִϸ����� ������Ʈ�� �ڽĿ��� ������
        animator = GetComponentInChildren<Animator>();
    }

    public void LeverSwitch()
    {
        // ���� ���� ���� ����
        animator.SetBool(IsSwitch, true);
    }


    // Start is called before the first frame update
    // �ܵ����� ����Ǵ��� üũ
    void Start()
    {
        LeverSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
