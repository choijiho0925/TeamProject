using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // UI에 표시할 시간 텍스트

    public float playTime; // 게임 진행 시간

    private void Update()
    {
        if (GameManager.Instance.isPlayingGame == false)
        {
            Time.timeScale = 0f; // 게임이 진행되지 않을 때 시간 정지
        }
        else
        {
            Time.timeScale = 1f; // 게임이 진행될 때 시간 흐름
        }

        if (GameManager.Instance.isPlayingGame)
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
}
