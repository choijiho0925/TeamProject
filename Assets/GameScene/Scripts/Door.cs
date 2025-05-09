using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float requiredStayTime = 2f;
    private float stayTimer = 0f;
    public LayerMask firePlayerLayer;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("퉁사후르 감지됨");
            stayTimer += Time.deltaTime;

            if (stayTimer > requiredStayTime)
            {
                Debug.Log("작동 조건 충족");
                //문에 도달하여 클리어되는 함수();
                this.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            stayTimer = 0f;
        }
    }
}
