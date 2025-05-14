using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerController controller;
    public ColorType bulletType; //�̳����� Ÿ�Լ���
    public LayerMask firePlayerLayer; // �����ĸ����̾�
    public LayerMask waterPlayerLayer;// Ÿ���ĸ����̾�
    public LayerMask Default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((Default.value & (1 << collision.gameObject.layer)) != 0)
            return;

        controller = collision.GetComponent<PlayerController>();
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        Destroy(gameObject);
        switch (bulletType)
        {
            case ColorType.Red:
                if (isPlayerW)
                {
                    Debug.Log("Ÿ���ĸ� ���");
                    controller.Dead();
                }
                break;

            case ColorType.Blue:
                if (isPlayerF)
                {
                    Debug.Log("�����ĸ� ���");
                    controller.Dead();
                }
                break;
        }
    }
}
