using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerController controller;
    public ColorType bulletType; //이넘으로 타입설정
    public LayerMask firePlayerLayer; // 퉁사후르레이어
    public LayerMask waterPlayerLayer;// 타사후르레이어

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
                    Debug.Log("타사후르 사망");
                    Destroy(gameObject);
                    controller.Dead();
                }
                break;

            case ColorType.Blue:
                if (isPlayerF)
                {
                    Debug.Log("퉁사후르 사망");
                    Destroy(gameObject);
                    controller.Dead();
                }
                break;
        }
    }
}
