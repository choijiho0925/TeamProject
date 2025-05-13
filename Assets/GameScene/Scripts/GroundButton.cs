using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    //�� ��ư�� ������ ������Ʈ�� ����Ʈ�� �����ؼ� �� ���� ���� �� �۵� �����ϵ��� ����
    public List<GameObject> targetObjects;

    //��ư���� ������ ������Ʈ���� IActivatable �������̽��� ���ؼ� �۵��ϴ� �̰͵� ����Ʈ�� ����
    private List<IActivatable> activatables = new List<IActivatable>();

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
        //������ Ÿ�� ������Ʈ���� �ݺ���
        foreach (var obj in targetObjects)
        {
            IActivatable a = obj.GetComponent<IActivatable>();
            if (a != null) activatables.Add(a);
        }
    }


    //�÷��̾�� �������� �� ��ȣ�ۿ� �� �� �ֵ���
    //Player�±׸� ���� ������Ʈ�� �۵� ����!!!!!

    //��ư�� �ö�
    private void OnTriggerEnter2D(Collider2D other)
    {
        //��ư�� ���� �ö󰡵� �������� �÷��̾ �ö��� ���� �۵��ǵ���
        GroundButtonSwitch();
        if (other.CompareTag("Player"))
        {
            foreach (var a in activatables)
                a.Activate();
        }
    }

    //��ư���� ������
    private void OnTriggerExit2D(Collider2D other)
    {
        GroundButtonNoSwitch();
        if (other.CompareTag("Player"))
        {
            foreach (var a in activatables)
                a.Deactivate();
        }
    }


}
