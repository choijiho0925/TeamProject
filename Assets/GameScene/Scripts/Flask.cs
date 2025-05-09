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
                    Debug.Log("퉁사후르가 빨강 플라스크를 획득");
                    Destroy(gameObject);
                    // Red Flask 획득 수 1 추가 아마 스테이지매니저내의 함수()
                }
                break;

            case ColorType.Blue:
                if (isPlayerW)
                {
                    Debug.Log("타사후르가 파랑 플라스크를 획득");
                    Destroy(gameObject);
                    // Blue Flask 획득 수 1 추가
                }
                break;
        }
    }
}
