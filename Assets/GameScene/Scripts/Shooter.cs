using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;// �ν����Ϳ��� ����ü ����
    Projectile projectile;
    public float interval = 2f; // ����ü �߻��ֱ�
    public float shootForce = 4f; // ����ü�� �ӵ�


    void Start()
    {
        InvokeRepeating("Shooting", interval, interval); //(Shootin�Լ���, interval�ʿ���, interval�ʻ��� �ð����� ����)
    }
    void Shooting()
    {
        GameObject proj = Instantiate(projectilePrefab, transform.position, transform.rotation);//������ ����ü�� ����ġ�� ����
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * shootForce, ForceMode2D.Impulse); // ���� ������Ʈ�� ���ϴ� �������� �߻�
        Vector2 dir = transform.up;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // ������Ʈ�� �ٶ󺸴� ���� �޾ƿ�
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // ������Ʈ�� �ٶ󺸴� ���⼳��
        proj.transform.rotation = rotation;
    }
}
