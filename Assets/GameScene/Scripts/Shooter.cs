using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;// 인스펙터에서 투사체 설정
    Projectile projectile;
    public float interval = 2f; // 투사체 발사주기
    public float shootForce = 4f; // 투사체의 속도


    void Start()
    {
        InvokeRepeating("Shooting", interval, interval); //(Shootin함수를, interval초에서, interval초사이 시간마다 실행)
    }
    void Shooting()
    {
        GameObject proj = Instantiate(projectilePrefab, transform.position, transform.rotation);//설정된 투사체를 현위치에 생성
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * shootForce, ForceMode2D.Impulse); // 현재 오브젝트가 향하는 방향으로 발사
        Vector2 dir = transform.up;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // 오브젝트가 바라보는 방향 받아옴
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // 오브젝트가 바라보는 방향설정
        proj.transform.rotation = rotation;
    }
}
