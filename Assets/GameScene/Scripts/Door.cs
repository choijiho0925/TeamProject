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
                stayTimer += Time.deltaTime;
                Debug.Log(stayTimer);
                if (stayTimer > requiredStayTime)
                {
                    Debug.Log("�۵� ���� ����");
                    //���� �����Ͽ� Ŭ����Ǵ� �Լ�();
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
