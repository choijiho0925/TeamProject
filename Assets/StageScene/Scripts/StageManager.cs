using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed = 5f; //카메라 이동 속도
    [SerializeField] private float minX, maxX, minY, maxY; //카메라 범위 제한
    [SerializeField] private float ObjPlusX = -1, OvjPlusY = 1; //카메라 중심부터 오브젝트가 떨어진 위치
    private Camera mainCam;
    private Vector3 targetPosition; //카메라 목표 위치
    private bool isMove = false; //카메라 움직임 여부
    private Vector3 mouseClickStartPosition; // 클릭 했을 시 마우스 월드 좌표
    private bool isDragging = false; // 현재 드래그 중인지 여부

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        CameraMove();
    }
    private void CameraMove()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            mouseClickStartPosition = mainCam.ScreenToWorldPoint(Input.mousePosition); // 마우스 시작 위치 기록

            RaycastHit2D hit = Physics2D.Raycast(mouseClickStartPosition, Vector2.zero);
            if (hit.collider != null)
            {
                // 오브젝트 클릭
                targetPosition = new Vector3(hit.transform.position.x + ObjPlusX, hit.transform.position.y + OvjPlusY, -10f); // 오브젝트 대비 위치값 수정
                isMove = true;

                isDragging = false; // 오브젝트 클릭 시 드래그 상태 해제
            }
            else
            {
                // 빈 공간 클릭, 드래그 시작
                
                isDragging = true;
            }

        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            CameraZoom(5);
            Vector3 currentMousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragOffset = mouseClickStartPosition - currentMousePosition; // 이동 거리 계산

            Vector3 newCameraPosition = mainCam.transform.position + dragOffset * Time.deltaTime * cameraMoveSpeed;

            // 위치를 범위 내로 제한
            newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);
            newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, minY, maxY);

            mainCam.transform.position = newCameraPosition;
        }

        // 마우스 왼쪽 버튼 떼졌을 때
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; // 드래그 종료
        }

        if (isMove)//카메라 이동
        {
            Vector3 currentPos = mainCam.transform.position;
            mainCam.transform.position = Vector3.Lerp(currentPos, targetPosition, cameraMoveSpeed * Time.deltaTime);
            CameraZoom(4);

            if (Vector3.Distance(currentPos, targetPosition) < 0.01f)
            {
                isMove = false;
            }

        }
    }

    private void CameraZoom(float zoomScale)
    {
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, zoomScale, Time.deltaTime * 4);
    }

    public void Stage1()
    {
        SceneManager.LoadScene(2); // 스테이지 1 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
    }
}
