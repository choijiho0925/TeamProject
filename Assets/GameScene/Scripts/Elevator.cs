using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //엘리베이터 최고,최저점
    public Transform topPoint;
    public Transform bottomPoint;

    //엘리베이터 스피드
    public float speed = 2f;

    //작동하는지 어디로 가는지 체크
    private bool isActivated = false;
    private bool isMovingUp = false;

    //플레이어와 접촉할 시(엘리베이터에 탔을 시) 활성화
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어나 큐브가 올라탈 시 작동
        if (collision.CompareTag("Player") || collision.CompareTag("Cube"))
        {
            Debug.Log("올라탐!");
            isActivated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //엘레베이터 움직여줌
        if (isActivated)
        {
            Debug.Log("이동중");
            MoveElevator();
        }

    }


    void MoveElevator()
    {
        //위로 움직인다면 탑포인트까지 이동, 아니면 바텀포인트까지 이동
        Vector3 target = isMovingUp ? topPoint.position : bottomPoint.position;

        //현재 위치에서 타겟 위치까지 일정 속도로 이동
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //타겟 위치까지 도착하면 비활성화(다시 내렸다가 탈 경우 작동) + 이동 방향을 바꿔줌
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isActivated = false;
            isMovingUp = !isMovingUp; // 왕복용
        }
    }
}
