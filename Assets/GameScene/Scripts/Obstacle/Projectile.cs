using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerController controller;
    public ColorType bulletType; //이넘으로 타입설정
    public LayerMask firePlayerLayer; // 퉁사후르레이어
    public LayerMask waterPlayerLayer;// 타사후르레이어
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
                    Debug.Log("타사후르 사망");
                    controller.Dead();
                }
                break;

            case ColorType.Blue:
                if (isPlayerF)
                {
                    Debug.Log("퉁사후르 사망");
                    controller.Dead();
                }
                break;
        }
    }
}
