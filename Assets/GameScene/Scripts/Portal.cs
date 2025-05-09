using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal targetPortal; // ����� ��Ż A�� B�� �ִٸ� �� �ٿ��� �ٿ��� ��
    public float teleportCooldown = 1f; //��Ÿ�� �־���� �� �ƴϸ� ��Ż�� ������ �������� �Դٰ�����

    private bool canTeleport = true; //���� ������ ���¸� bool ������ ǥ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canTeleport) return; //��Ż ��Ÿ�� ���̸� ����

        if (collision.CompareTag("Player") || collision.CompareTag("Cube"))//ť�곪 ĳ���͸� ����
        {
            //�ڷ���Ʈ�� ���� ��ü�� �ڷ���Ʈ ��Ű�� �ڷ�ƾ
            //������Ʈ ���� �������� �ڷ�ƾ�� ���� ������ �� ���� �ݺ��ϰ� �� �ܿ��� ������� �ʾƼ� �ڿ������� �����ϴٰ� ��
            StartCoroutine(Teleport(collision));
        }
    }

    private IEnumerator Teleport(Collider2D obj)
    {
        // ��Ż ������ �ٽ� �� ���� ��� ��Ȱ��ȭ ��Ű��
        canTeleport = false;
        //�ݴ��� ��Ż�� �� ���� ��� ��Ȱ��ȭ ��Ű��
        targetPortal.canTeleport = false;

        // ���� ��ü �ٷ� �����̵� ��Ű��
        obj.transform.position = targetPortal.transform.position;

        // ��� ���� ó�� (���� ���� ����)
        yield return new WaitForSeconds(teleportCooldown);

        //�ð� ������ �ٽ� Ȱ��ȭ ����
        canTeleport = true;
        targetPortal.canTeleport = true;
    }
}
