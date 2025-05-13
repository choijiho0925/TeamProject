using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //�� ��ư�� ������ ������Ʈ�� ����Ʈ�� �����ؼ� �� ���� ���� �� �۵� �����ϵ��� ����
    public List<GameObject> targetObjects;

    //��ư���� ������ ������Ʈ���� IActivatable �������̽��� ���ؼ� �۵��ϴ� �̰͵� ����Ʈ�� ����
    private List<IActivatable> activatables = new List<IActivatable>();

    // Animator �Ķ���� �̸��� �̸� �ؽ÷� ��ȯ�� ĳ�� (���� ����ȭ)
    private static readonly int IsSwitch = Animator.StringToHash("IsSwitch");

    //������ on/off �Ǿ��ִ��� bool ������ ����
    private bool isActivated = false;

    //��ó�� �÷��̾ �־�� �۵��� �� �ֵ��� bool ������ Ȯ��
    private bool playerInRange = false;




    protected Animator animator;


    protected virtual void Awake()
    {
        // �ִϸ����� ������Ʈ�� �ڽĿ��� ������
        animator = GetComponentInChildren<Animator>();
    }

    public void LeverSwitch()
    {
        // ���� ���� �ִϸ��̼� ����
        animator.SetBool(IsSwitch, true);
    }


    // Start is called before the first frame update
    // �ܵ����� ����Ǵ��� üũ
    void Start()
    {
        foreach (var obj in targetObjects)
        {
            IActivatable a = obj.GetComponent<IActivatable>();
            if (a != null) activatables.Add(a);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))//�÷��̾ ��ó�� �ְ� EŰ�� ������ ����
        {
            isActivated = !isActivated;

            foreach (var a in activatables)
            {
                if (isActivated) a.Activate();
                else a.Deactivate();
            }
            //�۵� �Ǿ��ٸ� �ִϸ��̼� ����
            LeverSwitch();
        }

    }


    //Player �±� �޸� �갡 ��ó�� �ִ��� ������ Ȯ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� ����");
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
