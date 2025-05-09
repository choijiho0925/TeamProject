using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlaskType
{
    Red,
    Blue
}

public class Flask : MonoBehaviour
{
    public FlaskType flasktype;
    public LayerMask firePlayerLayer;
    public LayerMask waterPlayerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (flasktype)
        {
            case FlaskType.Red:
                if (isPlayerF)
                {
                    Debug.Log("�����ĸ��� ���� �ö�ũ�� ȹ��");
                    Destroy(gameObject);
                    // Red Flask ȹ�� �� 1 �߰�
                }
                break;

            case FlaskType.Blue:
                if (isPlayerW)
                {
                    Debug.Log("Ÿ���ĸ��� �Ķ� �ö�ũ�� ȹ��");
                    Destroy(gameObject);
                    // Blue Flask ȹ�� �� 1 �߰�
                }
                break;
        }
    }
}
