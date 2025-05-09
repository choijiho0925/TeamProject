using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //���������� �ְ�,������
    public Transform topPoint;
    public Transform bottomPoint;

    //���������� ���ǵ�
    public float speed = 2f;

    //�۵��ϴ��� ���� ������ üũ
    private bool isActivated = false;
    private bool isMovingUp = false;

    //�÷��̾�� ������ ��(���������Ϳ� ���� ��) Ȱ��ȭ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�÷��̾ ť�갡 �ö�Ż �� �۵�
        if (collision.CompareTag("Player") || collision.CompareTag("Cube"))
        {
            Debug.Log("�ö�Ž!");
            isActivated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���������� ��������
        if (isActivated)
        {
            Debug.Log("�̵���");
            MoveElevator();
        }

    }


    void MoveElevator()
    {
        //���� �����δٸ� ž����Ʈ���� �̵�, �ƴϸ� ��������Ʈ���� �̵�
        Vector3 target = isMovingUp ? topPoint.position : bottomPoint.position;

        //���� ��ġ���� Ÿ�� ��ġ���� ���� �ӵ��� �̵�
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //Ÿ�� ��ġ���� �����ϸ� ��Ȱ��ȭ(�ٽ� ���ȴٰ� Ż ��� �۵�) + �̵� ������ �ٲ���
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isActivated = false;
            isMovingUp = !isMovingUp; // �պ���
        }
    }
}
