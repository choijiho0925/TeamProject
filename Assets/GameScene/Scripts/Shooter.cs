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
        rb.AddForce(-transform.up * shootForce, ForceMode2D.Impulse); // 현재 오브젝트가 향하는 방향으로 발사
        Vector2 dir = transform.up;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // 오브젝트가 바라보는 방향 받아옴
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // 오브젝트가 바라보는 방향설정
        proj.transform.rotation = rotation;
    }
}
