using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Flooring : MonoBehaviour
{
    PlayerController controller;
    //�ν�����
    public ColorType flooringType; // �̳����� � �������� ����
    public LayerMask firePlayerLayer; // �����ĸ� ���̾� ����
    public LayerMask waterPlayerLayer;// Ÿ���ĸ� ���̾� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (flooringType)
        {
            case ColorType.Red:
                if (isPlayerW)
                {
                    controller.Dead();
                }
                break;

            case ColorType.Blue:
                if (isPlayerF)
                {
                    controller.Dead();
                }
                break;

            case ColorType.Green:
                if (isPlayerF || isPlayerW)
                {
                    controller.Dead();
                }
                break;
        }      
    }
}
