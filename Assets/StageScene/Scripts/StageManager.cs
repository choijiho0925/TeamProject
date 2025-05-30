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
    [SerializeField] private Camera mainCam;

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
                if (hit.collider.gameObject.name == "Stage1")
                {
                    StageUIManager.Instance.stage1.SetActive(true); // 스테이지 1 버튼 활성화
                    StageUIManager.Instance.stage2.SetActive(false); // 스테이지 1 버튼 활성화
                }
                else if (hit.collider.gameObject.name == "Stage2")
                {
                    StageUIManager.Instance.stage1.SetActive(false); // 스테이지 1 버튼 활성화
                    StageUIManager.Instance.stage2.SetActive(true); // 스테이지 2 버튼 활성화
                }
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
        GoBackBtn();



    }
    private void GoBackBtn()
    {
        if (StageUIManager.Instance.ClickBackButton && !isMove)
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, new Vector3(0, 0, -10f), 6 * Time.deltaTime);
            if (Vector3.Distance(mainCam.transform.position, new Vector3(0, 0, -10f)) < 0.1f)
            {
                StageUIManager.Instance.ClickBackButton = false;
            }
            CameraZoom(5);
        }                
    }

    private void CameraZoom(float zoomScale)
    {
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, zoomScale, Time.deltaTime * 4);
    }


}
