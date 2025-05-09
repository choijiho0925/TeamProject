using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Flooring : MonoBehaviour
{
    PlayerController controller;
    //인스펙터
    public ColorType flooringType; // 이넘으로 어떤 장판인지 설정
    public LayerMask firePlayerLayer; // 퉁사후르 레이어 설정
    public LayerMask waterPlayerLayer;// 타사후르 레이어 설정
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (flooringType)
        {
            case ColorType.Red:
                if (isPlayerF)
                {
                    Debug.Log("타사후르사망");
                    controller.Dead();
                }
                break;

            case ColorType.Blue:
                if (isPlayerW)
                {
                    Debug.Log("퉁사후르사망");
                    controller.Dead();
                }
                break;

            case ColorType.Green:
                if (isPlayerF || isPlayerW)
                {
                    Debug.Log("공통 사망");
                    controller.Dead();
                }
                break;
        }      
    }
}
