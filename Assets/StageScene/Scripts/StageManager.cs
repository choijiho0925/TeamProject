using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed = 5f; //ī�޶� �̵� �ӵ�
    [SerializeField] private float minX, maxX, minY, maxY; //ī�޶� ���� ����
    [SerializeField] private float ObjPlusX = -1, OvjPlusY = 1; //ī�޶� �߽ɺ��� ������Ʈ�� ������ ��ġ
    private Camera mainCam;
    private Vector3 targetPosition; //ī�޶� ��ǥ ��ġ
    private bool isMove = false; //ī�޶� ������ ����
    private Vector3 mouseClickStartPosition; // Ŭ�� ���� �� ���콺 ���� ��ǥ
    private bool isDragging = false; // ���� �巡�� ������ ����

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
            mouseClickStartPosition = mainCam.ScreenToWorldPoint(Input.mousePosition); // ���콺 ���� ��ġ ���

            RaycastHit2D hit = Physics2D.Raycast(mouseClickStartPosition, Vector2.zero);
            if (hit.collider != null)
            {
                // ������Ʈ Ŭ��
                targetPosition = new Vector3(hit.transform.position.x + ObjPlusX, hit.transform.position.y + OvjPlusY, -10f); // ������Ʈ ��� ��ġ�� ����
                isMove = true;

                isDragging = false; // ������Ʈ Ŭ�� �� �巡�� ���� ����
            }
            else
            {
                // �� ���� Ŭ��, �巡�� ����
                
                isDragging = true;
            }

        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            CameraZoom(5);
            Vector3 currentMousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragOffset = mouseClickStartPosition - currentMousePosition; // �̵� �Ÿ� ���

            Vector3 newCameraPosition = mainCam.transform.position + dragOffset * Time.deltaTime * cameraMoveSpeed;

            // ��ġ�� ���� ���� ����
            newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minX, maxX);
            newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, minY, maxY);

            mainCam.transform.position = newCameraPosition;
        }

        // ���콺 ���� ��ư ������ ��
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; // �巡�� ����
        }

        if (isMove)//ī�޶� �̵�
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
        SceneManager.LoadScene(2); // �������� 1 ������ �̵�
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
        GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
    }
}
