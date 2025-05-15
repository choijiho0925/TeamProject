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
    //인스펙터
    public ColorType flasktype; //이넘으로 타입설정
    public LayerMask firePlayerLayer; // 퉁사후르레이어
    public LayerMask waterPlayerLayer;// 타사후르레이어

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
                    if (GameManager.Instance.stageCount == 1) { StageInformation.Instance.stage1_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 2) { StageInformation.Instance.stage1_2ItemCount++; }
                    else if (GameManager.Instance.stageCount == 3) { StageInformation.Instance.stage2_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 4) { StageInformation.Instance.stage2_2ItemCount++; }
                    Destroy(gameObject);
                }
                break;

            case ColorType.Blue:
                if (isPlayerW)
                {
                    if (GameManager.Instance.stageCount == 1) { StageInformation.Instance.stage1_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 2) { StageInformation.Instance.stage1_2ItemCount++; }
                    else if (GameManager.Instance.stageCount == 3) { StageInformation.Instance.stage2_1ItemCount++; }
                    else if (GameManager.Instance.stageCount == 4) { StageInformation.Instance.stage2_2ItemCount++; }
                    Destroy(gameObject);
                }
                break;
        }
    }
}
