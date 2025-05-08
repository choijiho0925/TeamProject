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
    public FlooringType flooringType;
    public LayerMask firePlayerLayer;
    public LayerMask waterPlayerLayer;
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
                    Debug.Log("퉁사후르사망");
                    // FirePlayer 사망 처리
                }
                break;

            case FlooringType.Water:
                if (isPlayerW)
                {
                    Debug.Log("타사후르사망");
                    // WaterPlayer 사망 처리
                }
                break;

            case FlooringType.poison:
                if (isPlayerF || isPlayerW)
                {
                    Debug.Log("공통 사망");
                    // 둘 중 하나라도 해당되면 사망 처리
                }
                break;
        }      
    }
}
