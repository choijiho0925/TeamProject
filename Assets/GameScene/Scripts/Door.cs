using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float requiredStayTime = 3f; //Ŭ������� ���տ� ����ؾ� �ϴ½ð�, �ִϸ��̼��� �ִ´ٸ� 
    private float stayTimer = 0f; //���տ� ����� �ð�
    public LayerMask firePlayerLayer; //�ν����Ϳ� �����ĸ� ���̾� ����ǥ��
    public Animator doorAnimation;

    private void Awake()
    {
        doorAnimation = GetComponentInChildren<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)// ������ٵ� naverStop��Ű�� �۵� ����
    {
            if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
                stayTimer += Time.deltaTime; // ���ð� ������
                doorAnimation.SetBool("IsClear", true); //�������� �ִϸ��̼�
            if (stayTimer > requiredStayTime)
            {     
                    //GameManager.Instance.Clear(); Ŭ����Ǵ� �Լ�
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // ������� ���ð� �ʱ�ȭ
    {
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            stayTimer = 0f;
            doorAnimation.SetBool("IsClear", false);
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
    //    Gamemanager.Instance.isPlayingGame = false;
    //    ���� UI SetActive = true
    //}
}
