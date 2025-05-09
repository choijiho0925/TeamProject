using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float requiredStayTime = 2f; //Ŭ������� ���տ� ����ؾ� �ϴ½ð�, �ִϸ��̼��� �ִ´ٸ� 
    private float stayTimer = 0f; //���տ� ����� �ð�
    public LayerMask firePlayerLayer; //�ν����Ϳ� �����ĸ� ���̾� ����ǥ��
    private void OnTriggerStay2D(Collider2D collision)// ������ٵ� naverStop��Ű�� �۵� ����
    {
            if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
                stayTimer += Time.deltaTime; // ���ð� ������
                Debug.Log(stayTimer);
                if (stayTimer > requiredStayTime)
                {
                    Debug.Log("�۵� ���� ����");
                    //GameManager.Instance.Clear(); Ŭ����Ǵ� �Լ�
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // ������� ���ð� �ʱ�ȭ
    {
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            stayTimer = 0f;
        }
    }

    //public void Clear() ���ӸŴ����� �������� �Լ�
    //{
    //    isSuccess = true;
    //    isPlayingGame = false;
    //    Ŭ���� UI SetActive = true
    //}

    //public void Dead() �÷��̾ ���� ���ӸŴ����� ���� ������
    //{
    //    //�÷��̾� ��� �ִϸ��̼� ���
    //    Destroy(gameObject);
    //    isPlayingGame = false;
    //    ���� UI SetActive = true
    //}
}
