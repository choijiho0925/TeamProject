using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum FlooringType
{
    Fire,
    Water,
    poison
}

public class Flooring : MonoBehaviour
{
    //�ν�����
    public FlooringType flooringType; // �̳����� � �������� ����
    public LayerMask firePlayerLayer; // �����ĸ� ���̾� ����
    public LayerMask waterPlayerLayer;// Ÿ���ĸ� ���̾� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (flooringType)
        {
            case FlooringType.Fire:
                if (isPlayerF)
                {
                    Debug.Log("�����ĸ����");
                    // FirePlayer ��� ó�� Dead();
                }
                break;

            case FlooringType.Water:
                if (isPlayerW)
                {
                    Debug.Log("Ÿ���ĸ����");
                    // WaterPlayer ��� ó�� Dead();
                }
                break;

            case FlooringType.poison:
                if (isPlayerF || isPlayerW)
                {
                    Debug.Log("���� ���");
                    // �� �� �ϳ��� �ش�Ǹ� ��� ó�� Dead();
                }
                break;
        }      
    }
}
