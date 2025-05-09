using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerController controller;
    public ColorType bulletType; //�̳����� Ÿ�Լ���
    public LayerMask firePlayerLayer; // �����ĸ����̾�
    public LayerMask waterPlayerLayer;// Ÿ���ĸ����̾�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (bulletType)
        {
            case ColorType.Red:
                if (isPlayerW)
                {
                    Debug.Log("Ÿ���ĸ� ���");
                    Destroy(gameObject);
                    controller.Dead();
                }
                break;

            case ColorType.Blue:
                if (isPlayerF)
                {
                    Debug.Log("�����ĸ� ���");
                    Destroy(gameObject);
                    controller.Dead();
                }
                break;
        }
    }
}
