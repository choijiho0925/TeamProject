using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFan : MonoBehaviour
{
    public float liftForce = 10f; //올려보낼 힘 인스펙터창에서 설정

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            Vector2 direction = transform.up;
            rb.AddForce(direction * liftForce, ForceMode2D.Force);// liftForce만큼 힘을 줌
        }
    }
    public void Activate()
    {
    }

    public void Deactivate()
    {       
    }
}
