using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    Projectile projectile;
    public float interval = 2f;
    public float shootForce = 4f;


    void Start()
    {
        InvokeRepeating("Shooting", interval, interval);
    }
    void Shooting()
    {
        GameObject proj = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * shootForce, ForceMode2D.Impulse); // ���� ������Ʈ�� ���ϴ� �������� �߻�
        Vector2 dir = transform.up;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // ������Ʈ�� �ٶ󺸴� ���� �޾ƿ�
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // ������Ʈ�� �ٶ󺸴� ���⼳��
        proj.transform.rotation = rotation;
    }
}
