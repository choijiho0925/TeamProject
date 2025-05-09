using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFan : MonoBehaviour
{
    public float liftForce = 10f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(Vector2.up * liftForce, ForceMode2D.Force);
        }
    }
}
