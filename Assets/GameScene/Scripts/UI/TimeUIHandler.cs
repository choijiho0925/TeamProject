using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // UI에 표시할 시간 텍스트

    public float playTime; // 게임 진행 시간

    private void Start()
    {
        playTime = 0f; // 초기화
    }

    private void Update()
    {
        if (GameManager.Instance.isCheckTime)
        {
            playTime += Time.deltaTime; // 게임 진행 시간 업데이트
            UpdateTimeText(); // UI 업데이트
        }
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(playTime / 60f);
        float seconds = playTime % 60f;
        timeText.text = $"{minutes:00}:{seconds:00.00}";
    }

    public void StartTime()
    {
        GameManager.Instance.isCheckTime = true; // 시간 체크 시작
        Time.timeScale = 1f; // 게임이 진행될 때 시간 흐름
    }

    public void StopTime()
    {
        GameManager.Instance.isCheckTime = false; // 시간 체크 중지
        Time.timeScale = 0f; // 게임이 멈출 때 시간 정지
    }
}
