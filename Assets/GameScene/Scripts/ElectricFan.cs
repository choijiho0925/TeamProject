using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFan : MonoBehaviour
{
    public float liftForce = 10f; //�÷����� �� �ν�����â���� ����

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            Vector2 direction = transform.up;
            rb.AddForce(direction * liftForce, ForceMode2D.Force);// liftForce��ŭ ���� ��
        }
    }
    public void Activate()
    {
    }

    public void Deactivate()
    {       
    }
}
