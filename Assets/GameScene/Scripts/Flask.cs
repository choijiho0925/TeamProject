using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
{
    Red,
    Blue,
    Green,
    None
}

public class Flask : MonoBehaviour
{
    //�ν�����
    public ColorType flasktype; //�̳����� Ÿ�Լ���
    public LayerMask firePlayerLayer; // �����ĸ����̾�
    public LayerMask waterPlayerLayer;// Ÿ���ĸ����̾�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (flasktype)
        {
            case ColorType.Red:
                if (isPlayerF)
                {
                    Debug.Log("�����ĸ��� ���� �ö�ũ�� ȹ��");
                    Destroy(gameObject);
                    if (GameManager.Instance.stageCount == 1) { StageInformation.Instance.stage1_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 2) { StageInformation.Instance.stage1_2ItemCount++; }
                    else if (GameManager.Instance.stageCount == 3) { StageInformation.Instance.stage2_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 4) { StageInformation.Instance.stage2_2ItemCount++; }
                }
                break;

            case ColorType.Blue:
                if (isPlayerW)
                {
                    Debug.Log("Ÿ���ĸ��� �Ķ� �ö�ũ�� ȹ��");
                    Destroy(gameObject);
                    if (GameManager.Instance.stageCount == 1) { StageInformation.Instance.stage1_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 2) { StageInformation.Instance.stage1_2ItemCount++; }
                    else if (GameManager.Instance.stageCount == 3) { StageInformation.Instance.stage2_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 4) { StageInformation.Instance.stage2_2ItemCount++; }
                }
                break;
        }
    }
}
